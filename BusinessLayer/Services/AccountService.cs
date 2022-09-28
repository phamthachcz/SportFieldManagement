
using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class AccountService
    {
        private static AccountService instance;

        public static AccountService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountService();
                }
                return AccountService.instance;
            }
            private set => AccountService.instance = value;
        }

        //0: Success: 1: False: 2: Have Blank
        public int Login(string login, string password)
        {
            if(login == string.Empty && password == string.Empty)
            {
                return 2;
            }
            if(AccountDataMaper.Instance.AccountLogin(login, password))
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public Account getUserDetailbyLogin(string login)
        {
            
            return AccountDataMaper.Instance.getUserDetailbyLogin(login);
        }

        public bool AccountUpdate(string login, string password, string newPassword)
        {

            
            return AccountDataMaper.Instance.AccountUpdate(login,   password, newPassword);
        }

        public bool AccountSignUp(string login, string password, int type, string fname, string lname, int gender, string phone, string email, DateTime birthday)
        {
            if(AccountDataMaper.Instance.AccountInsert(login, password, type))
            {
                Account idSignup = getUserDetailbyLogin(login);
                return EmployeeService.Instance.InsertEmployee(idSignup.Id, fname, lname, gender, phone, email, birthday);
            }

            return false ;
        }
    }
}
