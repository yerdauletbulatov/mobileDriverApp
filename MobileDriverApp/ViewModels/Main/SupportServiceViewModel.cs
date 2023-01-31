using MobileDriverApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class SupportServiceViewModel : BaseViewModel
{
        public SupportServiceViewModel(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
