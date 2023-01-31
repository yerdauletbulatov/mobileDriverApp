using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Helper;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using System.Collections.ObjectModel;
using MobileDriverApp.Helper.DisplayAlert;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class OnReviewOrdersViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;
        public ObservableCollection<OrderInfo> OrdersInfo { get; set; } = new();

        public OnReviewOrdersViewModel(HttpClient httpClient) : base(httpClient)
        {
            IsBusy = false;
        }
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
                var ordersForDriver = await _httpClient.ResponseDataPostAsync<List<OrderInfo>>(API.OnReviewOrders);
                ordersForDriver?.ForEach(c => OrdersInfo.Add(c));
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
