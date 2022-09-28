using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class EmployeeService
    {
        private static EmployeeService instance;

        public static EmployeeService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeService();
                }
                return EmployeeService.instance;
            }
            private set => EmployeeService.instance = value;
        }

        public bool InsertEmployee(int idAccount, string fname, string lname, int gender, string phone, string email, DateTime birthday)
        {
            return EmployeeDataMaper.Instance.Insert(idAccount, fname, lname, gender, phone, email, birthday);
        }

        public bool UpdateEmployee(int idAccount, string fname, string lname, int gender, string phone, string email, DateTime birthday)
        {
            
            return EmployeeDataMaper.Instance.Update(idAccount, fname, lname, gender, phone, email, birthday);
        }
        public Employee getAccountDetailbyId(int Account_id)
        {
            
            return EmployeeDataMaper.Instance.getAccountDetailbyId(Account_id);
        }
    }
}
