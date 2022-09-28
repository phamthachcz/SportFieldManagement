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
    public class FacilityDataMaper
    {
        private static FacilityDataMaper instance;

        public static FacilityDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacilityDataMaper();
                }
                return FacilityDataMaper.instance;
            }
            private set => FacilityDataMaper.instance = value;
        }

        public bool FacilityInsert(string name, string detail, int facCategory, float price)
        {
            string query = string.Format("INSERT INTO [Facility] VALUES ('{0}', '{1}', {2}, {3})", name, detail, facCategory, price);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }



        public List<Facility> GetFacilityListByIdCategory(int id)
        {
            List<Facility> facilities = new List<Facility>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Facility where FacilityCategory_id =" + id);
            foreach (DataRow item in data.Rows)
            {
                Facility facility = new Facility(item);
                facilities.Add(facility);
            }
            return facilities;
        }

        public List<Facility> GetFacilityList()
        {
            List<Facility> facilities = new List<Facility>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM Facility");
            foreach (DataRow item in data.Rows)
            {
                Facility facility = new Facility(item);
                facilities.Add(facility);
            }
            return facilities;
        }
    }
}
