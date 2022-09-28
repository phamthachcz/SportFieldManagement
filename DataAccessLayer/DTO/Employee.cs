using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class Employee
    {
        public Employee(int account_id, string first_name, string last_name, int gender, string phone, string email, DateTime date_of_birth)
        {
            this.Account_id = account_id;
            this.First_name = first_name;
            this.Last_name = last_name;
            this.Gender = gender;
            this.Phone = phone;
            this.Email = email;
            this.Date_of_birth = date_of_birth;
        }

        public Employee(DataRow row)
        {
            this.Account_id = (int)row["Account_id"];
            this.First_name = row["first_name"].ToString();
            this.Last_name = row["last_name"].ToString();
            this.Gender = (int)row["gender"];
            this.Phone = row["phone"].ToString();
            this.Email = row["email"].ToString();
            this.Date_of_birth = (DateTime)row["date_of_birth"];
        }



        private int account_id;
        private string first_name;
        private string last_name;
        private int gender;
        private string phone;
        private string email;
        private DateTime date_of_birth;

        public int Account_id { get => account_id; set => account_id = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public DateTime Date_of_birth { get => date_of_birth; set => date_of_birth = value; }
    }
}
