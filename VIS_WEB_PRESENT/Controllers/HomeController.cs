using BusinessLayer.Services;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VIS_WEB_PRESENT.Code;
using VIS_WEB_PRESENT.Models;

namespace VIS_WEB_PRESENT.Controllers
{
    public class HomeController : Controller
    {

        private List<string> timeToString = new List<string>() { 
            "6:00", "7:00", "8:00", "9:00", "10:00", "11:00", "12:00",
            "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00",
            "20:00", "21:00"
        
        };

        

        private DateTime dateselected;
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup()
        {
            var listGender = new[]{
                new {ID = 0, Name = "Male"},
                new {ID = 1, Name = "Female"},
                new {ID = 2, Name = "Undetected"},
            }.ToList();
            ViewBag.GenderList = listGender;
            return View();
        }

        public ActionResult Shop()
        {
            ViewBag.Shops = ShopService.Instance.ReadDataShop();
            return View();
        }

        [HttpPost]
        public ActionResult Signup(SignupForm signupForm)
        {
            if (ModelState.IsValid)
            {
                if(AccountService.Instance.AccountSignUp(signupForm.Login, signupForm.Password, 3, signupForm.FirstName, signupForm.LastName, signupForm.Gender, signupForm.Phone, signupForm.Email, DateTime.Parse(signupForm.BirthDay)))
                {
                    return RedirectToAction("SuccessPage", "Home", new { @id = 3 });
                }
                else
                {
                    return RedirectToAction("Signup", "Home");
                }
            }
            else
            {
                return RedirectToAction("Signup", "Home");
            }
            
        }

        public ActionResult Login()
        {
            
            
            if(User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Detail");
            }
            else
            {
                return View();
            }
            
        }

        [Authorize]
        public ActionResult Detail()
        {
            ViewBag.User = User.Identity.Name;

            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Reservation()
        {
            ViewBag.User = User.Identity.Name;
            var listSports = FacilityCategoryService.Instance.GetFacilityCateList();
            ViewBag.ListSports = listSports;

            return View();
        }

        [Authorize]
        public ActionResult DetailReservation(int id, string time)
        {
            DateTime dateTime;
            if(time == null)
            {
                dateTime = DateTime.Now;
            }
            else
            {
                double time_get = double.Parse(time);
                dateTime = UnixTimeStampToDateTime(time_get / 1000);
                
            }
            this.dateselected = dateTime;
            ViewBag.User = User.Identity.Name;
            
            Dictionary<string, List<int>> dicvalue = new Dictionary<string, List<int>>();
            List<Facility> facilities = FacilityService.Instance.GetFacilitiesByIDCategory(id);
            foreach (Facility facility in facilities)
            {
                List<TimeTable> timeTables = TimeTableService.Instance.GetTimeTableByDay(dateTime.Day, facility.Id);
                List<int> status = new List<int>();
                foreach(TimeTable st in timeTables)
                {
                    status.Add(st.Status);
                }
                dicvalue[facility.Name] = status;

            }

            var listPayment = new []{
                new {ID = 1, Name = "Card"},
                new {ID = 2, Name = "Cash"},
            }.ToList();


            ViewBag.DicTimetables = dicvalue;
            
            ViewBag.DaySelect = dateTime.ToString("yyyy-MM-dd");
            ViewBag.TimeTable = timeToString;
            ViewBag.SelectFacilities = new SelectList(facilities, "id", "name", id);
            ViewBag.Facilities = facilities;
            ViewBag.ListPayment = listPayment;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult DetailReservation(BookingForm bookingForm)
        {
            if (ModelState.IsValid)
            {
                Account account = AccountService.Instance.getUserDetailbyLogin(User.Identity.Name);
                BookingService.Instance.MakeBooking(account.Id, bookingForm.FacilityID, "make by " + account.Login, int.Parse(bookingForm.TimeBook));
                return RedirectToAction("SuccessPage", "Home", new { @id = 1 });
            }
            return View();
        }

        [Authorize]
        public ActionResult SuccessPage(int id)
        {
            if(id == 1)
            {
                ViewBag.Booking = "Your successfully created your booking";
                ViewBag.ID = 1;
            }
            else if(id == 2)
            {
                ViewBag.Booking = "Your successfully cancel your booking";
                ViewBag.ID = 2;
            }
            else if (id == 3)
            {
                ViewBag.Booking = "Congratulations, your account has been successfully created.";
                ViewBag.ID = 3;
            }
            ViewBag.User = User.Identity.Name;
            return View();
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public JsonResult LoadTimebyFacility(string FacilityID, string DayInput)
        {
            DateTime dateinput = DateTime.Parse(DayInput);
            var phyList = TimeTableService.Instance.GetSportFieldFree(dateinput.Day,Convert.ToInt32(FacilityID));

            var lst = new[]
            {
                new {ID = 0, Name = "Select Time"}
            }.ToList();
            
            
            foreach(var item in phyList)
            {
                lst.Add(new { ID = item.Id, Name = item.Start_time.ToString("HH:mm") });
                
            }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginForm loginForm)
        {
            if (ModelState.IsValid)
            {
                //int result = AccountService.Instance.Login(loginForm.Login, loginForm.Password);
                if (Membership.ValidateUser(loginForm.Login, loginForm.Password))
                {
                    Account account = AccountService.Instance.getUserDetailbyLogin(loginForm.Login);

                    //SessionHelper.SetSession(new UserSession() { Login = account.Login });
                    FormsAuthentication.SetAuthCookie(account.Login, true);
                    return RedirectToAction("Detail");
                }
                else
                {
                    ModelState.AddModelError("", "Password is not correct!");
                    return View();
                }
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        [Authorize]
        public ActionResult History()
        {
            ViewBag.User = User.Identity.Name;
            Account account = AccountService.Instance.getUserDetailbyLogin(User.Identity.Name);
            List<History> histories = HistoryService.Instance.getBookingHistory(account.Id);

            var time = DateTime.Now.TimeOfDay.TotalSeconds + 10800;
            ViewBag.Histories = histories;
            
            return View();
        }

        [Authorize]

        public ActionResult HistoryCancel(int id)
        {
            
            Account account = AccountService.Instance.getUserDetailbyLogin(User.Identity.Name);
            List<History> histories = HistoryService.Instance.getBookingHistory(account.Id);
            History history = null;
            foreach(var item in histories)
            {
                if(item.IdBooking == id)
                {
                    history = item;
                    break;
                }
            }
            if(history == null)
            {
                return View("History");
            }
            if (HistoryService.Instance.cancelBooking(history.IdBooking, history.TimeID))
            {
                return RedirectToAction("SuccessPage", "Home", new { @id = 2 });
            }
            

            return View("History");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}