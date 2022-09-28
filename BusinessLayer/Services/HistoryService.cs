using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class HistoryService
    {
        private static HistoryService instance;

        public static HistoryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HistoryService();
                }
                return HistoryService.instance;
            }
            private set => HistoryService.instance = value;
        }

        public List<History> getBookingHistory(int idAccount)
        {
            return HistoryDataMaper.Instance.GetHistoryByIDUser(idAccount);
        }

        public bool cancelBooking(int idBooking, int timeID)
        {
            return HistoryDataMaper.Instance.CancelBooking(idBooking, timeID);
        }
    }
}
