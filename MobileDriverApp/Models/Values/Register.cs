using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Values
{
    public class RegisterDriver : BaseModel
    {
        public string PhoneNumber { get; set; }
        public RegisterDriver(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
