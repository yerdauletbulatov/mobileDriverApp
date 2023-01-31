using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Storage;
using MobileDriverApp.Helper;
using MobileDriverApp.Helper.DisplayAlert;
using MobileDriverApp.Helper.Extentions;
using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels.Base;
using MobileDriverApp.Views.Main;

namespace MobileDriverApp.ViewModels.Register
{
    public partial class ProceedRegisterViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _surname;

        [ObservableProperty]
        private bool _isRunning;

        [ObservableProperty]
        private string _name;

        [ObservableProperty]
        private string _identityCardFaceScanPath;

        [ObservableProperty]
        private string _identityCardBackScanPath;

        [ObservableProperty]
        private string _drivingLicenceScanPath;

        [ObservableProperty]
        private string _driverPhoto;  

        [ObservableProperty]
        private string _phoneNumber = Preferences.Get(nameof(DriverInfo.PhoneNumber), string.Empty);

        public ProceedRegisterViewModel(HttpClient httpClient) : base(httpClient)
        {
        }

        [ICommand]
        async void ProceedRegister()
        {
            try
            {
                IsRunning = true;
                DriverInfo driverInfo = new()
                {
                    Name = _name,
                    Surname = _surname,
                    PhoneNumber = _phoneNumber,
                    IdentityCardFaceScanPath = _identityCardFaceScanPath,
                    IdentityCardBackScanPath = _identityCardBackScanPath,
                    DrivingLicenceScanPath = _drivingLicenceScanPath,
                    DriverPhoto = _driverPhoto,
                    IsDriver = true
                };

                var driver = await _httpClient.ResponseDataPostAsync(API.ProceedRegister, driverInfo);
                Preferences.Set(nameof(DriverInfo.Name), driver.Name);
                Preferences.Set(nameof(DriverInfo.Surname), driver.Surname);
                await Shell.Current.GoToAsync($"{nameof(CreateCarPage)}");
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

        [ICommand]
        public async void UploadFile(string fileType)
        {
            var photo = await MediaPicker.PickPhotoAsync();

            var task = new FirebaseStorage("test-10022.appspot.com", new FirebaseStorageOptions
            {
                ThrowOnCancel = true,
            })
                .Child("Driver")
                .Child($"{_name} {_surname}")
                .Child(photo.FileName)
                .PutAsync(await photo.OpenReadAsync());

            var downloadLink = await task;

            switch (fileType)
            {
                case "back":
                    _identityCardBackScanPath = downloadLink;
                    break;
                case "fase":
                    _identityCardFaceScanPath = downloadLink;
                    break;
                case "licence":
                    _drivingLicenceScanPath = downloadLink;
                    break;
                case "photo":
                    _driverPhoto = downloadLink;
                    break;
            }
        }
    }
}
