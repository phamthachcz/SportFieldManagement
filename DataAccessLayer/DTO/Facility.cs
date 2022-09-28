using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.DTO
{
    public class Facility
    {

        public Facility(int id, string name, string detail, int facilityCategory_id, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Detail = detail;
            this.FacilityCategory_id = facilityCategory_id;
            this.Price = price;
        }

        public Facility(DataRow row)
        {
            this.Id = (int)row["id"];
            this.Name = row["name"].ToString();
            this.Detail = row["detail"].ToString();
            this.FacilityCategory_id = (int)row["FacilityCategory_id"];
            this.Price = (double)row["price"];
        }

        private int id;

        private string name;

        private string detail;

        private int facilityCategory_id;

        private double price;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Detail { get => detail; set => detail = value; }
        public int FacilityCategory_id { get => facilityCategory_id; set => facilityCategory_id = value; }
        public double Price { get => price; set => price = value; }
    }
}
