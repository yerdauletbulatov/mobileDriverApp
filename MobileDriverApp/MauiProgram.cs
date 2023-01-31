using MobileDriverApp.Helper;
using MobileDriverApp.Intefaces;
using MobileDriverApp.Models;
using MobileDriverApp.Models.Values;
using MobileDriverApp.Repositories;
using MobileDriverApp.Services;
using MobileDriverApp.ViewModels;
using MobileDriverApp.ViewModels.Main;
using MobileDriverApp.ViewModels.Register;
using MobileDriverApp.Views.Main;
using MobileDriverApp.Views.Register;
using MobileDriverApp.Models.Entities;

namespace MobileDriverApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        //Hub
        builder.Services.AddSingleton<INotification, Notification>();

        //Services
        builder.Services.AddScoped<HttpClient>();
        builder.Services.AddScoped<API>();

        //IStorages

        builder.Services.AddScoped<IStorage<DriverInfo>, AppDataStorage<DriverInfo>>();
        builder.Services.AddScoped<IStorage<DriverAppDataInfo>, AppDataStorage<DriverAppDataInfo>>();

        //Views
        builder.Services.AddTransient<RoutePage>();
        builder.Services.AddTransient<KitPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ConfirmRegisterPage>();
        builder.Services.AddTransient<ProceedRegisterPage>();
        builder.Services.AddTransient<HistoryOrderPage>();
        builder.Services.AddTransient<SupportServicePage>();
        builder.Services.AddTransient<CreateRoutePage>();
        builder.Services.AddTransient<CreateCarPage>();
        builder.Services.AddTransient<OnReviewOrdersPage>();
        builder.Services.AddTransient<DetailOrderPage>();
        builder.Services.AddTransient<ActiveOrdersPage>();

        //View Models
        builder.Services.AddTransient<RouteViewModel>();
        builder.Services.AddTransient<KitViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ConfirmRegisterViewModel>();
        builder.Services.AddTransient<ProceedRegisterViewModel>();
        builder.Services.AddTransient<HistoryOrderViewModel>();
        builder.Services.AddTransient<SupportServiceViewModel>();
        builder.Services.AddTransient<CreateRouteTripViewModel>();
        builder.Services.AddTransient<CreateCarViewModel>();
        builder.Services.AddTransient<AppShellViewModel>();
        builder.Services.AddTransient<OnReviewOrdersViewModel>();
        builder.Services.AddTransient<DetailOrderViewModel>();
        builder.Services.AddTransient<ActiveOrdersViewModel>();

        return builder.Build();
    }
}
