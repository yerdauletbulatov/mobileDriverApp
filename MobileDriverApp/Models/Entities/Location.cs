using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Entities
{
    public class Location : BaseModel
    {
        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
        public double Latitude { get;  set; }
        public double Longitude { get;  set; }
    }
}
