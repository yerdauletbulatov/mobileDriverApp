using MobileDriverApp.Models.Base;

namespace MobileDriverApp.Models.Entities
{
    public class City : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
