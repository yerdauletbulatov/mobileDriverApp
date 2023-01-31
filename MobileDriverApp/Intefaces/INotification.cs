using Microsoft.AspNetCore.SignalR.Client;
using MobileDriverApp.Models.Values;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Intefaces
{
    public interface INotification
    {
        public void SendMyLoaction();
        public void StopSendMyLocation();
    }
}
