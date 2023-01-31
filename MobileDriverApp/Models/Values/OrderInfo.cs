using System;
using MobileDriverApp.Models.Entities;
using Location = MobileDriverApp.Models.Entities.Location;

namespace MobileDriverApp.Models.Values
{
    public class OrderInfo
    {
        public int OrderId { get; set; }
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
        public Package Package { get; set; }
        public CarType CarType { get; set; }
        public string StateName { get; set; }
        public bool IsSingle { get; set; }
        public decimal Price { get; set; }
        public string ClientPhoneNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string ClientName { get; set; }
        public string ClientSurname { get; set; }
        public Location Location { get; set; }
    }
}
