using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.ViewModels.Base
{
    public abstract class BaseViewModel : ObservableObject
    {
        protected readonly HttpClient _httpClient;
        public BaseViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
