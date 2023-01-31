using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.AspNetCore.SignalR.Client;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Views.Main;
using System.Collections.ObjectModel;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class RouteViewModel : BaseViewModel
    {
        [ObservableProperty]
        private bool _isBusy;

        public ObservableCollection<RouteTripInfo> RouteTripsInfo { get; set; } = new();
        private INotification notification;

        public RouteViewModel(INotification notification, HttpClient httpClient) : base(httpClient)
        {
            IsBusy = false;
            this.notification = notification;
        }

        [ICommand]
        async Task Refresh()
        {
            try
            {
                IsBusy = true;
                await Task.Delay(1000);
                RouteTripsInfo.Clear();
                var routeTripInfo = await _httpClient.ResponseDataPostAsync<RouteTripInfo>(API.ActiveRouteTrip);
                RouteTripsInfo.Add(routeTripInfo);
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

        [ICommand]
        async Task CreateRoute()
        {
            await Shell.Current.GoToAsync($"{nameof(CreateRoutePage)}");
        }  
        [ICommand]
        void SendLocation()
        {
            notification.SendMyLoaction();
        }    
        [ICommand]
        void StopSendLocation()
        {
            notification.StopSendMyLocation();
        }



        public async void ContentPage_Appearing(object sender, EventArgs e) =>
           await Refresh();
    }
}
