using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class FacilityService
    {
        private static FacilityService instance;

        public static FacilityService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacilityService();
                }
                return FacilityService.instance;
            }
            private set => FacilityService.instance = value;
        }

        public bool FacilityInsert(string name, string detail, int facCategory, float price)
        {

            return FacilityDataMaper.Instance.FacilityInsert(name, detail, facCategory, price);
        }

        public List<Facility> GetFacilityList()
        {
            
            return FacilityDataMaper.Instance.GetFacilityList();
        }

        public List<Facility> GetFacilitiesByIDCategory(int id)
        {
            return FacilityDataMaper.Instance.GetFacilityListByIdCategory(id);
        }
    }
}
