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
    public class FacilityCategoryDataMaper
    {
        private static FacilityCategoryDataMaper instance;

        public static FacilityCategoryDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacilityCategoryDataMaper();
                }
                return FacilityCategoryDataMaper.instance;
            }
            private set => FacilityCategoryDataMaper.instance = value;
        }

        public List<FacilityCategory> GetFacilityCateList()
        {
            List<FacilityCategory> facilityCategories = new List<FacilityCategory>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM FacilityCategory");
            foreach (DataRow item in data.Rows)
            {
                FacilityCategory facilityCategory = new FacilityCategory(item);
                facilityCategories.Add(facilityCategory);
            }
            return facilityCategories;
        }
    }
}
