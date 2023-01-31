using System;
using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class RouteTrip : BaseModel
    {
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Location Location { get; set; }

        public RouteTrip(City startCity, City finishCity, DateTime deliveryDate)
        {
            StartCity = startCity;
            FinishCity = finishCity;
            DeliveryDate = deliveryDate; 
        }
        public RouteTrip()
        {
        }
    }
}
