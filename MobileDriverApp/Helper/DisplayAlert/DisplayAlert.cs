using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileDriverApp.Helper.DisplayAlert
{
    public static class DisplayAlert
    {
        public async static void NotCorrect()
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", "Неверное заполнение", "Повторите еще раз");
        }
        public async static void NotFullInfo()
        {
            await App.Current.MainPage.DisplayAlert("Ошибка", "Заполните все данные", "Повторите еще раз");
        }
        public async static void ExceptionMessage(string message)
        {
            await App.Current.MainPage.DisplayAlert("Информация", message, "Закрыть");
        }    
        public async static void AddCarMessage()
        {
            await App.Current.MainPage.DisplayAlert("Добавление автомобиля", "Автомобиль успешно добавлен", "Ок");
        }
    }
}
