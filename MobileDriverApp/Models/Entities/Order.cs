using System;
using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class Order : BaseModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
    //    public Package Package { get; set; }
        public DateTime DateTime { get; set; }
     //   public CarType CarType { get; set; }
        public bool IsSingle { get; set; }
        public decimal Price { get; set; }
    }
}
