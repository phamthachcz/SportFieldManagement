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
    public class AccountDataMaper
    {
        private static AccountDataMaper instance;

        public static AccountDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDataMaper();
                }
                return AccountDataMaper.instance;
            }
            private set => AccountDataMaper.instance = value;
        }

        public bool AccountInsert(string login, string password, int type)
        {
            string query = string.Format("INSERT INTO [Account] VALUES ('{0}', '{1}', {2})", login, password, type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public bool AccountLogin(string login, string password)
        {
            string query = string.Format("Select dbo.CheckLogin('{0}', '{1}') as IsLogin", login, password);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return (bool)data.Rows[0]["IsLogin"] == true;

        }

        public bool AccountUpdate(string login, string password, string newPassword)
        {

            int result = DataProvider.Instance.ExecuteNonQuery("EXEC UserUpdate @p_login , @p_password , @p_newPassword", new object[] { login, password, newPassword });
            return result > 0;
        }

        public Account getUserDetailbyId(int id)
        {
            Account acc = null;
            string query = string.Format("Select * from Account WHERE id = {0}", id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                acc = new Account(item);
                return acc;
            }
            return acc;
        }

        public Account getUserDetailbyLogin(string login)
        {
            Account acc = null;
            string query = string.Format("Select * from Account WHERE login = '{0}'", login);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                acc = new Account(item);
                return acc;
            }
            return acc;
        }
    }
}
