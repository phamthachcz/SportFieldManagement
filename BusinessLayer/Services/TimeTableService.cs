using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class TimeTableService
    {
        private static TimeTableService instance;

        public static TimeTableService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TimeTableService();
                }
                return TimeTableService.instance;
            }
            private set => TimeTableService.instance = value;
        }

        public bool TimeTableInsert(DateTime startTime, DateTime endTime, int facility, int status)
        {
            return TimeTableDataMaper.Instance.TimeTableInsert(startTime, endTime, facility, status);
        }

        public List<TimeTable> GetTimeTableList()
        {
            
            return TimeTableDataMaper.Instance.GetTimeTableList();
        }

        public List<TimeTable> GetTimeTableByDay(int day, int Facility_id)
        {
            
            return TimeTableDataMaper.Instance.GetTimeTableByDay(day, Facility_id);
        }

        public List<TimeTable> GetSportFieldFree(int day, int Facility_id)
        {

            return TimeTableDataMaper.Instance.GetTimeTableFreeByDay(day, Facility_id);
        }
    }
}
