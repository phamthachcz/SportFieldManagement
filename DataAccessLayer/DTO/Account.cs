using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
   
    public class Account
    {
        public Account(int id, string login, string password, int type)
        {
            this.Id = id;
            this.Login = login;
            this.Password = password;
            this.Type = type;
        }

        public Account(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Login = row["login"].ToString();
            this.Password = row["password"].ToString();
            this.Type = (int)row["type"];
        }

        public Account() { }

        private int id;
        private string login;
        private string password;
        private int type;

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Password { get => password; set => password = value; }
        public int Type { get => type; set => type = value; }

        
    }
}
