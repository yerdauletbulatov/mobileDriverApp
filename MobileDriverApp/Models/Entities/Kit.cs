using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class Kit : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
