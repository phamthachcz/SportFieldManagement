using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class Booking
    {

        public Booking(int id, int account_id, int facility_id, string detail, int status, int timeTable_ID) 
        {
            this.Id = id;
            this.Account_id = account_id;
            this.Facility_id = facility_id;
            this.Detail = detail;
            this.Status = status;
            this.TimeTable_ID = timeTable_ID;
        }

        public Booking(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Account_id = (int)row["Account_id"]; 
            this.Facility_id = (int)row["Facility_id"];
            this.Detail = row["detail"].ToString();
            this.Status = (int)row["status"]; ;
            this.TimeTable_ID = (int)row["TimeTable_ID"]; ;
        }

        private int id;

        private int account_id;

        private int facility_id;

        private string detail;

        private int status;

        private int timeTable_ID;

        public int Id { get => id; set => id = value; }
        public int Account_id { get => account_id; set => account_id = value; }
        public int Facility_id { get => facility_id; set => facility_id = value; }
        public string Detail { get => detail; set => detail = value; }
        public int Status { get => status; set => status = value; }
        public int TimeTable_ID { get => timeTable_ID; set => timeTable_ID = value; }
    }
}
