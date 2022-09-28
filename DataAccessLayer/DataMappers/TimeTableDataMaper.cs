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
    public class TimeTableDataMaper
    {
        private static TimeTableDataMaper instance;

        public static TimeTableDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeTableDataMaper();
                }
                return TimeTableDataMaper.instance;
            }
            private set => TimeTableDataMaper.instance = value;
        }

        public bool TimeTableInsert(DateTime startTime, DateTime endTime, int facility, int status)
        {
            string query = string.Format("INSERT INTO [TimeTable] VALUES ('{0}', '{1}', {2}, {3})", startTime.ToString("yyyy.MM.dd HH:mm:ss"), endTime.ToString("yyyy.MM.dd HH:mm:ss"), facility, status);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }

        public List<TimeTable> GetTimeTableList()
        {
            List<TimeTable> timeTables = new List<TimeTable>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM TimeTable");
            foreach (DataRow item in data.Rows)
            {
                TimeTable time = new TimeTable(item);
                timeTables.Add(time);
            }
            return timeTables;
        }

        public List<TimeTable> GetTimeTableByDay(int day, int Facility_id)
        {
            string updateTable = string.Format("Update TimeTable \n" +
                "set status = 2 \n" +
                "where (Year(start_time) < Year(GETDATE()) or Month(start_time) < Month(GETDATE()) \n" +
                "or Day(start_time) <= Day(GETDATE())) and (DATEPART(HOUR, start_time) <= DATEPART(HOUR, GETDATE()) and status = 0)");
            DataProvider.Instance.ExecuteQuery(updateTable);
            List<TimeTable> timeTables = new List<TimeTable>();
            string query = string.Format("SELECT * FROM TimeTable where Day(start_time) = {0} and Facility_id = {1}", day, Facility_id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeTable time = new TimeTable(item);
                timeTables.Add(time);
            }
            return timeTables;
        }

        public List<TimeTable> GetTimeTableFreeByDay(int day, int Facility_id)
        {
            List<TimeTable> timeTables = new List<TimeTable>();
            string query = string.Format("SELECT * FROM TimeTable where Day(start_time) = {0} and Facility_id = {1} and status = 0", day, Facility_id);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                TimeTable time = new TimeTable(item);
                timeTables.Add(time);
            }
            return timeTables;
        }
    }
}
