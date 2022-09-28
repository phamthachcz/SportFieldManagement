using DataAccessLayer.DataMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class BookingService
    {
        private static BookingService instance;

        public static BookingService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingService();
                }
                return BookingService.instance;
            }
            private set => BookingService.instance = value;
        }

        public bool MakeBooking(int account_id, int facility_id, string detail, int timetable_id)
        {
            return BookingDataMaper.Instance.InsertNewBook(account_id, facility_id, detail, timetable_id);
        }
    }
}
