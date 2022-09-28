using DataAccessLayer.DataAccess;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataMappers
{
    public class EmployeeDataMaper
    {
        private static EmployeeDataMaper instance;

        public static EmployeeDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EmployeeDataMaper();
                }
                return EmployeeDataMaper.instance;
            }
            private set => EmployeeDataMaper.instance = value;
        }

        public bool Insert(int idAccount, string fname, string lname, int gender, string phone, string email, DateTime birthday)
        {
            string query = string.Format("SET DATEFORMAT DMY\nINSERT INTO [Employee] VALUES ({0},'{1}','{2}',{3},'{4}', '{5}', '{6}')", idAccount, fname, lname, gender, phone, email, birthday.ToString("dd.MM.yyyy"));
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool Update(int idAccount, string fname, string lname, int gender, string phone, string email, DateTime birthday)
        {
            string query = string.Format("SET DATEFORMAT DMY\nUPDATE Employee SET first_name = '{1}', last_name = '{2}', gender = {3}, phone = '{4}', email = '{5}', date_of_birth = '{6}' WHERE Account_id = {0}", idAccount, fname, lname, gender, phone, email, birthday.ToString("dd.MM.yyyy"));
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public Employee getAccountDetailbyId(int Account_id)
        {
            Employee acc = null;
            string query = string.Format("Select * from Employee WHERE Account_id = {0}", Account_id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                acc = new Employee(item);
                return acc;
            }
            return acc;
        }
    }
}
