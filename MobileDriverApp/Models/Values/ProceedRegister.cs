using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Values
{
    public class ProceedRegisterDriver : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityCardFaceScanPath { get; set; }
        public string IdentityCardBackScanPath { get; set; }
        public string DrivingLicenceScanPath { get; set; }
        public string DriverPhoto { get; set; }
        public bool IsDriver { get; set; }
    }
}
