using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models;
using MobileDriverApp.ViewModels.Base;
using System.Collections.ObjectModel;
using MobileDriverApp.Models.Entities;


namespace MobileDriverApp.ViewModels.Main
{
    public partial class KitViewModel : BaseViewModel
    {
        private readonly IStorage<DriverAppDataInfo> _appStorage;

        [ObservableProperty]
        private Kit _kit;

        public ObservableCollection<Kit> KitList { get; set; } = new ObservableCollection<Kit>();

        public KitViewModel(HttpClient httpClient, IStorage<DriverAppDataInfo> appStorage) : base(httpClient)
        {
            _appStorage = appStorage;
            KitList = new ObservableCollection<Kit>(_appStorage.GetData().Kits);
        }

        [ICommand]
        public async void BuyKit()
        {
            if(Kit == null)
            {
                await App.Current.MainPage.DisplayAlert("Нет", "Нет", "Нет");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Купили", "Купили", "Ok");
            }
        }
    }
}
