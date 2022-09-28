using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class Shop
    {
        public Shop(int id, string name, double price, string type)
        {
            this.Id = id;
            this.Name = name;
            this.Price = price;
            this.Type = type;
        }

        
        private int id;
        private string name;
        private double price;
        private string type;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public double Price { get => price; set => price = value; }
        public string Type { get => type; set => type = value; }
    }
}
