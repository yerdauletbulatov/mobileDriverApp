using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileDriverApp.Models.Entities;

namespace MobileDriverApp.Models.Values
{
    public class DriverInfo : BaseModel
    {
        public Car Car { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string IdentityCardFaceScanPath { get; set; }
        public string IdentityCardBackScanPath { get; set; }
        public string DrivingLicenceScanPath { get; set; }
        public string DriverPhoto { get; set; }
        public bool IsValid { get; set; }
        public bool IsDriver { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string SmsCode { get; set; }
        public DriverInfo(string phoneNumber, string smsCode)
        {
            PhoneNumber = phoneNumber;
            SmsCode = smsCode;
            IsDriver = true;
        }
        public DriverInfo()
        {
        }
    }
}
