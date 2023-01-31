using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Views.Register;
using System.Net;
using System.Text.Json;

namespace MobileDriverApp.ViewModels.Register
{
    public partial class RegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _phoneNumber;
        [ObservableProperty]
        private bool _isRunning;
        public RegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async void Register()
        {
            try
            {
                IsRunning = true;
                Preferences.Clear();
                Preferences.Set(nameof(DriverInfo.PhoneNumber), PhoneNumber);
                await _httpClient.ResponseDataPostAsync(API.Register, new RegisterDriver(PhoneNumber));
                await Shell.Current.GoToAsync($"{nameof(ConfirmRegisterPage)}");
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
            finally
            {
                IsRunning = false;
            }
        }
    }
}
