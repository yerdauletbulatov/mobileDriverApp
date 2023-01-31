using System.Collections.Generic;
using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class DriverAppDataInfo : BaseModel
    {
        public int Id { get; set; }
        public List<City> Cities { get; set; }
        public List<Kit> Kits { get; set; }
        public List<CarType> CarTypes { get; set; }
        public List<CarBrand> CarBrands { get; set; }
        public List<CarColor> CarColors { get; set; }
    }
}
