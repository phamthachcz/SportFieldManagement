using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DataMappers
{
    public class ShopDataMaper
    {
        private static ShopDataMaper instance;

        public static ShopDataMaper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ShopDataMaper();
                }
                return ShopDataMaper.instance;
            }
            private set => ShopDataMaper.instance = value;
        }

        public List<Shop> GetShopsList()
        {
            return XMLProvider.Instance.ReadShop();
        }
    }
}
