using DataAccessLayer.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccessLayer
{
    public class XMLProvider
    {
        private static XMLProvider instance;

        public static XMLProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new XMLProvider();
                return XMLProvider.instance;
            }
            private set
            {
                XMLProvider.instance = value;
            }
        }
        private XmlDocument doc;

        public List<Shop> ReadShop()
        {
            List<Shop> shops = new List<Shop>();
            this.doc = new XmlDocument();
            string solutiondir = AppDomain.CurrentDomain.BaseDirectory + @"\bin\SmallShop.xml";
            this.doc.Load(solutiondir);
            foreach (XmlNode coinNode in this.doc.SelectNodes("/Shops/Shop"))
            {
                XmlNode idNode = coinNode.SelectSingleNode("Id");
                XmlNode nameNode = coinNode.SelectSingleNode("Name");
                XmlNode priceNode = coinNode.SelectSingleNode("Price");
                XmlNode typeNode = coinNode.SelectSingleNode("Type");
                int id = 0;
                string name = null;
                double price = 0;
                string type = null;
                if (idNode != null)
                {
                    id = int.Parse(idNode.Attributes["value"].Value);
                }
                if (nameNode != null)
                {
                    name = nameNode.Attributes["value"].Value;
                }
                if (priceNode != null)
                {
                    price = double.Parse(priceNode.Attributes["value"].Value);
                }

                if (typeNode != null)
                {
                    type = typeNode.Attributes["value"].Value;
                }
                Shop shop = new Shop(id, name, price, type);

                shops.Add(shop);
                
            }
            return shops;
        }
    }
}
