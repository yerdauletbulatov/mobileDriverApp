using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Values
{
    public class ConfirmRegisterDriver : BaseModel
    {
        public string SmsCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDriver { get; set; }
    }
}
