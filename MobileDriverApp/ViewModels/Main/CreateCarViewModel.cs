using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MobileDriverApp.Controls.ModelControl;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models;
using MobileDriverApp.ViewModels.Base;
using System.Collections.ObjectModel;
using MobileDriverApp.Models.Entities;

namespace MobileDriverApp.ViewModels.Main
{
    public partial class CreateCarViewModel : BaseViewModel
    {
        private const int START_YEAR = 1990;
        private readonly IStorage<DriverAppDataInfo> _appStorage;

        [ObservableProperty]
        public CarType _carType;

        [ObservableProperty]
        public CarBrand _carBrand;

        [ObservableProperty]
        public CarColor _carColor;

        [ObservableProperty]
        public string _registrationCertificate;

        [ObservableProperty]
        public string _licensePlate;

        [ObservableProperty]
        public int _productionYear;

        public ObservableCollection<CarType> CarTypeList { get; private set; }
        public ObservableCollection<CarColor> CarColorList { get; private set; }
        public ObservableCollection<CarBrand> CarBrandList { get; private set; }
        public ObservableCollection<int> Years { get; set; } = new(Enumerable.Range(START_YEAR, DateTime.Now.AddYears(+1).Year - START_YEAR).ToList());

        public CreateCarViewModel(HttpClient httpClient, IStorage<DriverAppDataInfo> appStorage) : base(httpClient)
        {   
            _appStorage = appStorage;
            CarTypeList = new ObservableCollection<CarType>(_appStorage.GetData().CarTypes);
            CarColorList = new ObservableCollection<CarColor>(_appStorage.GetData().CarColors);
            CarBrandList = new ObservableCollection<CarBrand>(_appStorage.GetData().CarBrands);
        }

        [ICommand]
        public async Task AddCar()
        {
            if (CarType == null || CarColor == null || CarBrand == null || RegistrationCertificate == null || LicensePlate == null || ProductionYear == 0)
            {
                DisplayAlert.NotFullInfo();
                return;
            }
            try
            {
                var car = new Car()
                {
                    CarTypeId = CarType.Id,
                    CarColorId = CarColor.Id,
                    CarBrandId = CarBrand.Id,
                    RegistrationCertificate = RegistrationCertificate,
                    LicensePlate = LicensePlate,
                    ProductionYear = ProductionYear
                };

                await _httpClient.ResponseDataPostAsync(API.CreateCar, car);
                DisplayAlert.AddCarMessage();
                await AppConstant.AddFlyoutMenusDetails();
            }
            catch (Exception ex)
            {
                DisplayAlert.ExceptionMessage(ex.Message);
            }
        }

        [ICommand]
        public async Task NextPageAsync()
        {
            await AppConstant.AddFlyoutMenusDetails();
        }
    }
}
