using DataAccessLayer.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataMappers
{
    public class BookingDataMaper
    {
        private static BookingDataMaper instance;

        public static BookingDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BookingDataMaper();
                }
                return BookingDataMaper.instance;
            }
            private set => BookingDataMaper.instance = value;
        }

        public bool InsertNewBook(int account_id, int facility_id, string detail, int timetable_id)
        {
            string query = string.Format("INSERT INTO [Booking] VALUES ({0}, {1},'{2}', 0, {3})", account_id, facility_id, detail, timetable_id);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
