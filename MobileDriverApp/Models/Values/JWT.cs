using MobileDriverApp.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Models.Values
{
    public class JWT : BaseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public JWT(string refreshToken, string accessToken = "")
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
        }
        public JWT()
        {
        }
    }
}
