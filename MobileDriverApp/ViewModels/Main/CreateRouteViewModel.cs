using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Intefaces;
using MobileDriverApp.ViewModels.Base;
using System.Collections.ObjectModel;
using MobileDriverApp.Models.Entities;
using Location = MobileDriverApp.Models.Entities.Location;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class CreateRouteTripViewModel : BaseViewModel
    {
        private readonly IStorage<DriverAppDataInfo> _appStorage;

        [ObservableProperty]
        private City _startCity; 
        
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private City _finishCity;

        [ObservableProperty]
        private DateTime _deliveryDate;

        public ObservableCollection<City> CityList { get; set; }

        public CreateRouteTripViewModel(IStorage<DriverAppDataInfo> appStorage, HttpClient httpClient) : base(httpClient)
        {
            _appStorage = appStorage;
            CityList = new ObservableCollection<City>(_appStorage.GetData().Cities);
            _deliveryDate = DateTime.Now;
        }

        [ICommand]
        public async Task CreateRouteTrip()
        {
            if (StartCity == null && FinishCity == null && StartCity == FinishCity)
            {
                DisplayAlert.NotCorrect();
                return;
            }
            try
            {
                IsBusy = true;
                var location = await GetLocation();
                await _httpClient.ResponseDataPostAsync(API.CreateRouteTrip, new RouteTrip(StartCity, FinishCity, DeliveryDate) { Location = location});
                await Shell.Current.GoToAsync($"..");
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

        async Task<Location> GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLocationAsync();
                return new Location(location.Latitude, location.Longitude);
            }
            catch
            {
                return null;
            }
        }

    }
}
