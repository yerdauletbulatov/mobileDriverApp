using Microsoft.Maui.Controls;
using MobileDriverApp.Models;
using MobileDriverApp.Shared;
using MobileDriverApp.Views.Main;

namespace MobileDriverApp.Controls.ModelControl
{
    public class AppConstant
    {
        public async static Task AddFlyoutMenusDetails()
        {
            if(AppShell.Current.FlyoutHeader is null)
            {
                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();
                var OrderPageInfo = AppShell.Current.Items.Where(f => f.Route == nameof(RoutePage)).FirstOrDefault();
                if (OrderPageInfo != null) AppShell.Current.Items.Remove(OrderPageInfo);


                var flyoutItem = new FlyoutItem()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                        {
                        new ShellContent
                            {
                            Icon = Icons.Dashboard,
                            Title = "Моя поездка",
                            ContentTemplate = new DataTemplate(typeof(RoutePage)),
                            Route = nameof(RoutePage)
                            }
                        }
                };
                var flyoutItem2 = new FlyoutItem()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
                    Icon = Icons.AboutUs,
                    Title = "Заказы",
                    Items =
                    {
                    new ShellContent
                        {
                            Icon = Icons.CarIcon,
                            Title = "Активные",
                            ContentTemplate = new DataTemplate(typeof(ActiveOrdersPage)),
                            Route = nameof(ActiveOrdersPage)
                        },
                    new ShellContent
                        {
                            Icon = Icons.CarIcon,
                            Title = "На рассмотрении",
                            ContentTemplate = new DataTemplate(typeof(OnReviewOrdersPage)),
                            Route = nameof(OnReviewOrdersPage)
                        }
                    }
                };
                var flyoutItem3 = new FlyoutItem()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                        {
                            new ShellContent
                            {
                                Icon = Icons.Dashboard,
                                Title = "Добавить транспорт",
                                ContentTemplate = new DataTemplate(typeof(CreateCarPage)),
                                Route = nameof(CreateCarPage)
                            },
                            new ShellContent
                            {
                                Icon = Icons.Dashboard,
                                Title = "Купить пакет",
                                ContentTemplate = new DataTemplate(typeof(KitPage)),
                                Route = nameof(KitPage)
                            },
                            new ShellContent
                            {
                                Icon = Icons.AboutUs,
                                Title = "История заказов",
                                ContentTemplate = new DataTemplate(typeof(HistoryOrderPage)),
                                Route = nameof(HistoryOrderPage)
                            },
                            new ShellContent
                            {
                                Icon = Icons.AboutUs,
                                Title = "Служба поддержки",
                                ContentTemplate = new DataTemplate(typeof(SupportServicePage)),
                                Route = nameof(SupportServicePage)
                            }
                        }
                };

                AppShell.Current.Items.Add(flyoutItem);
                AppShell.Current.Items.Add(flyoutItem2);
                AppShell.Current.Items.Add(flyoutItem3);    
            }
                await Shell.Current.GoToAsync($"//{nameof(RoutePage)}");
        }
    }
}
