using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Helper;
using MobileDriverApp.Models;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Views.Main;

namespace MobileDriverApp.ViewModels
{
    
    public partial class DetailOrderViewModel : BaseViewModel
    {
        [ObservableProperty]
        private OrderInfo _orderInfo;
        public DetailOrderViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async Task ConfirmOrder()
        {
            try
            {
                await _httpClient.ResponseDataPostAsync(API.ConfirmOrder, OrderInfo);
                await App.Current.MainPage.DisplayAlert("Заказ", "Вы приняли заказ", "Ok");
                await Shell.Current.GoToAsync($"..");
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            } 
        }
        [ICommand]
        async Task RejectOrder()
        {
            try
            {
                var result = await Shell.Current.DisplayAlert("Заказ", $"Вы точно хотите отменить заказ", "Да", "Нет");
                if (result)
                {
                    await _httpClient.ResponseDataPostAsync(API.RejectOrder, OrderInfo);
                    await App.Current.MainPage.DisplayAlert("Заказ", "Вы отклонили заказ", "Ok");
                    await Shell.Current.GoToAsync($"..");
                }
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }

        }
    }
}
