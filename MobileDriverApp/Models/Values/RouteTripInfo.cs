using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileDriverApp.Models.Entities;

namespace MobileDriverApp.Models.Values
{
    public class RouteTripInfo
    {
        public City StartCity { get; set; }
        public City FinishCity { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
