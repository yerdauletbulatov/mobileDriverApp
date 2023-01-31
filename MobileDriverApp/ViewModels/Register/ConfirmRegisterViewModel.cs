using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Controls.ModelControl;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Views.Main;
using MobileDriverApp.Views.Register;
using System.Net;

namespace MobileDriverApp.ViewModels.Register
{
    public partial class ConfirmRegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _smsCode;

        [ObservableProperty]
        private bool _isRunning;

        public ConfirmRegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        public async void ConfirmRegister()
        {
            try
            {
                IsRunning = true;
                var driverInfo = await _httpClient.ResponseDataPostAsync(API.ConfirmRegister, new DriverInfo(Preferences.Get(nameof(DriverInfo.PhoneNumber), string.Empty), SmsCode));
                Preferences.Set(nameof(JWT.AccessToken), driverInfo.AccessToken);
                Preferences.Set(nameof(JWT.RefreshToken), driverInfo.RefreshToken);
                if (driverInfo.IsValid)
                {
                    Preferences.Set(nameof(DriverInfo.Name), driverInfo.Name);
                    Preferences.Set(nameof(DriverInfo.Surname), driverInfo.Surname);
                    await AppConstant.AddFlyoutMenusDetails();
                }
                else
                {
                    await Shell.Current.GoToAsync($"{nameof(ProceedRegisterPage)}");
                }
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
