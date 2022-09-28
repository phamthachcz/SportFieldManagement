using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class TimeTable
    {

        public TimeTable(int id, DateTime start_time, DateTime end_time, int facility_id, int status)
        {
            this.Id = id;
            this.Start_time = start_time;
            this.End_time = end_time;
            this.Facility_id = facility_id;
            this.Status = status;
        }

        public TimeTable(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Start_time = (DateTime)row["start_time"];
            this.End_time = (DateTime)row["end_time"];
            this.Facility_id = (int)row["Facility_id"];
            
            

            this.Status = (int)row["status"];
        }


        private int id;

        private DateTime start_time;

        private DateTime end_time;

        private int facility_id;


        private int status;

        

        public int Id { get => id; set => id = value; }
        public DateTime Start_time { get => start_time; set => start_time = value; }
        public DateTime End_time { get => end_time; set => end_time = value; }
        public int Facility_id { get => facility_id; set => facility_id = value; }
        public int Status { get => status; set => status = value; }
    }
}
