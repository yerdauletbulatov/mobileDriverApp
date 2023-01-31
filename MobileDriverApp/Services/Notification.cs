using Microsoft.AspNetCore.SignalR.Client;
using MobileDriverApp.Helper;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models.Entities;
using MobileDriverApp.Models.Values;

namespace MobileDriverApp.Services
{
    public class Notification : INotification
    {
        private TimerCallback _tm;
        private Timer _timer;

        private readonly HubConnection _connection;

        public Notification()
        {
            // создаем подключение к хабу
            _connection = new HubConnectionBuilder().WithUrl($"{API.Hub}", options =>
            {
                var token = Preferences.Get(nameof(JWT.AccessToken), string.Empty);
                options.AccessTokenProvider = async () => await Task.FromResult(token);
            }).Build();

            // регистрируем функцию SendToDriver для получения данных
            _connection.On<string>("SendToDriver", async (message) =>
            {
                await SendLocalMessage(message);
            });

            // череp 10 секунду переподключаемся   
            _connection.Closed += async (error) =>
            {
                await Task.Delay(10000); 
                _connection.StartAsync();
            };
            //подключение хабу
            _connection.StartAsync();
        }
        private async Task SendLocalMessage(string message)
        {
            await Shell.Current.DisplayAlert("Уведомление", $"{message}", "Ок");
        }
        public void SendMyLoaction()
        {
            _tm = new TimerCallback(async (state) => await SendLocation(state));
            _timer = new Timer(_tm, null, 0, 10000);
        }
        private async Task SendLocation(object obj)
        {
            try
            {
                var geoLocation = await Geolocation.GetLocationAsync();
                var locationCommand = new LocationCommand()
                {
                    Latitude = geoLocation.Latitude,
                    Longitude = geoLocation.Longitude,
                    DriverName = Preferences.Get(nameof(DriverInfo.Name), string.Empty),
                    DriverSurname = Preferences.Get(nameof(DriverInfo.Surname), string.Empty),
                    DriverPhoneNumber = Preferences.Get(nameof(DriverInfo.PhoneNumber), string.Empty)

            };
                await _connection.InvokeCoreAsync("ReceiveDriverLocation", args: new[] { locationCommand });
            }
            catch
            {
            }
        }
        public void StopSendMyLocation()
        {
           _timer.Dispose();
        }
    }
}
