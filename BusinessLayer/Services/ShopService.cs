using DataAccessLayer.DataMappers;
using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ShopService
    {
        private static ShopService instance;

        public static ShopService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShopService();
                }
                return ShopService.instance;
            }
            private set => ShopService.instance = value;
        }

        public List<Shop> ReadDataShop()
        {
            return ShopDataMaper.Instance.GetShopsList();
        }
    }
}
