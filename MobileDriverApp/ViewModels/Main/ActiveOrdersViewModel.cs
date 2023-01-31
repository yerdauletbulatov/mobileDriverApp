using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class ActiveOrdersViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;

        public ActiveOrdersViewModel(HttpClient httpClient) : base(httpClient)
        {
            IsBusy = false;
        }

        public ObservableCollection<OrderInfo> OrdersInfo { get; set; } = new();

        public async void ContentPage_Appearing(object sender, EventArgs e) =>
           await Refresh();

        [ICommand]
        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                OrdersInfo.Clear();
                var orderIfnolist = await _httpClient.ResponseDataPostAsync<List<OrderInfo>>(API.ActiveOrders);
                foreach (var item in orderIfnolist)
                {
                    OrdersInfo.Add(item);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
