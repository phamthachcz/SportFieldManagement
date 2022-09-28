using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class History
    {
        public History(int idBooking,int account_id, int status, int isPaid, string nameFacility, double price, DateTime start_time, DateTime end_time, string nameSport, int timeID)
        {
            this.IdBooking = idBooking;
            this.Account_id = account_id;
            this.Status = status;
            this.IsPaid = isPaid;
            this.NameFacility = nameFacility;
            this.Price = price;
            this.Start_time = start_time;
            this.End_time = end_time;
            this.NameSport = nameSport;
            this.TimeID = TimeID;
        }

        public History(DataRow row)
        {
            this.IdBooking = (int)row["id"];
            this.Account_id = (int)row["Account_id"];
            this.Status = (int)row["status"]; 
            this.IsPaid = (int)row["isPaid"]; 
            this.NameFacility = row["nameFacility"].ToString(); 
            this.Price = (double)row["price"]; 
            this.Start_time = (DateTime)row["start_time"]; 
            this.End_time = (DateTime)row["end_time"]; 
            this.NameSport = row["nameSport"].ToString();
            this.TimeID = (int)row["TimeID"];
        }

        private int timeID;
        private int idBooking;
        private int account_id;
        private int status;
        private int isPaid;
        private string nameFacility;
        private double price;
        private DateTime start_time;
        private DateTime end_time;
        private string nameSport;

        public int Account_id { get => account_id; set => account_id = value; }
        public int Status { get => status; set => status = value; }
        public int IsPaid { get => isPaid; set => isPaid = value; }
        public string NameFacility { get => nameFacility; set => nameFacility = value; }
        public double Price { get => price; set => price = value; }
        public DateTime Start_time { get => start_time; set => start_time = value; }
        public DateTime End_time { get => end_time; set => end_time = value; }
        public string NameSport { get => nameSport; set => nameSport = value; }
        public int IdBooking { get => idBooking; set => idBooking = value; }
        public int TimeID { get => timeID; set => timeID = value; }
    }
}
