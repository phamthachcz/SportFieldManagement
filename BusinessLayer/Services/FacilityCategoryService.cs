using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class FacilityCategoryService
    {
        private static FacilityCategoryService instance;

        public static FacilityCategoryService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FacilityCategoryService();
                }
                return FacilityCategoryService.instance;
            }
            private set => FacilityCategoryService.instance = value;
        }

        public List<FacilityCategory> GetFacilityCateList()
        {
            return FacilityCategoryDataMaper.Instance.GetFacilityCateList();
        }

    }
}
