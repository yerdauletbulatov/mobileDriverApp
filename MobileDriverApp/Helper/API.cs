using MobileDriverApp.Models;
using MobileDriverApp.Models.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileDriverApp.Models.Entities;

namespace MobileDriverApp.Helper
{
    public class API
    {
        private static readonly string _host = "http://172.31.208.1:5000";

        public readonly Dictionary<string, string> _apiKey = new ()
        {
            { nameof(DriverAppDataInfo), _host + "/api/driver/appData" },
            { nameof(DriverInfo), _host + "/api/userData" }
        };
        public static string Hub => _host + "/api/notification";
        public static string RefreshAccess => _host + "/api/refreshToken";
        public static string Register => _host + "/api/register";
        public static string ConfirmRegister => _host + "/api/confirmRegister";
        public static string ProceedRegister => _host + "/api/proceedRegister";
        public static string CreateRouteTrip => _host + "/api/driver/createRouteTrip";
        public static string CreateCar => _host + "/api/driver/createCar";
        public static string ConfirmOrder => _host + "/api/driver/confirmOrder";
        public static string RejectOrder => _host + "/api/driver/rejectOrder";
        public static string OnReviewOrders => _host + "/api/driver/onReviewOrders";
        public static string ActiveRouteTrip => _host + "/api/driver/activeRouteTrip";
        public static string ActiveOrders => _host + "/api/driver/activeOrders";
    }
}
