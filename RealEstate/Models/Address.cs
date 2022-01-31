using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int TownID { get; set; }
        public string Details { get; set; }
        public int CityID { get; set; }
        public int CountryID { get; set; }
    }
}