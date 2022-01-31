using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstate.Models
{
    public class Role
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte Level { get; set; }
    }
}