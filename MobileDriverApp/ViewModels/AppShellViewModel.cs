using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Models;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Views.Register;
using System.Text.Json;

namespace MobileDriverApp.ViewModels
{
    public partial class AppShellViewModel
    {
        public AppShellViewModel() 
        {
        }

        [ICommand]
        async void SignOut()
        {
            await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
