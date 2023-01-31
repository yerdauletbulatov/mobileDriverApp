using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class Car : BaseModel
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public int CarTypeId { get; set; }
        public CarType CarType { get; set; }
        public int CarColorId { get; set; }
        public CarBrand CarColor { get; set; }
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
        public string RegistrationCertificate { get; set; }
        public string LicensePlate { get; set; }
        public int ProductionYear { get; set; }
    }
}
