using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Entities
{
    public class Route : BaseModel
    {
        public City StartCity { get; set; }

        public City FinishCity { get; set; }
    }
}
