using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class AddressTown
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
    }
}