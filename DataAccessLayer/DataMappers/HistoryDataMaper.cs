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
    public class HistoryDataMaper
    {
        private static HistoryDataMaper instance;

        public static HistoryDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HistoryDataMaper();
                }
                return HistoryDataMaper.instance;
            }
            private set => HistoryDataMaper.instance = value;
        }

        public List<History> GetHistoryByIDUser(int idUser)
        {
            List<History> histories = new List<History>();
            string query = string.Format("select Booking.id, Account_id, booking.status, bill.isPaid, Facility.name as nameFacility, Facility.price, TimeTable.start_time, TimeTable.end_time, FacilityCategory.name as nameSport, TimeTable.id as TimeID \n " +
                "from Booking \n"  +
                "join bill on bill.Booking_id = booking.id \n" +
                "join Facility on Facility.id = Booking.Facility_id \n" +
                "join TimeTable on TimeTable.id = Booking.TimeTable_ID \n" +
                "join FacilityCategory on FacilityCategory.id = Facility.FacilityCategory_id \n"+
                "where Booking.Account_id = {0}", idUser);
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                History history = new History(item);
                histories.Add(history);
            }
            return histories;
        }

        public bool CancelBooking(int idBooking, int timeID)
        {
            string query = string.Format("DELETE FROM bill WHERE Booking_id = {0}", idBooking);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            query = string.Format("DELETE FROM Booking WHERE id = {0}", idBooking);

            result = DataProvider.Instance.ExecuteNonQuery(query);

            query = string.Format("Update TimeTable set status = 0 where id = {0}", timeID);
            result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
