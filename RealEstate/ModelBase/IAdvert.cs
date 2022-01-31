using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealEstate.Models;
using RealEstate.ModelBase;

namespace RealEstate.ModelBase
{
    interface IAdvert
    {
        int AdvertiseID { get; set; }
        DateTime Date { get; set; }
        bool IsActive { get; set; }
        string Title { get; set; }
        string Explaination { get; set; }
        User User { get; set; }
        
    }
}
