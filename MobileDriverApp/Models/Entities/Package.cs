using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Entities
{
    public class Package
    {
        public string Name { get;  set; }
        public double Length { get;  set; }
        public double Width { get;  set; }
        public double Height { get;  set; }
        public double Weight { get;  set; }
    }
}
