using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RealEstate.ModelBase;

namespace RealEstate.Models
{
    public class AdvertResidential : IAdvert
    {
        public int AdvertiseID { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Title { get; set; }
        public string Explaination { get; set; }
        public User User { get; set; }
        public Residential RealEstate { get; set; }
    }
}