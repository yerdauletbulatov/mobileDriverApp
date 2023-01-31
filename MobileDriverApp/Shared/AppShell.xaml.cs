using MobileDriverApp.ViewModels;
using MobileDriverApp.Views.Main;
using MobileDriverApp.Views.Register;

namespace MobileDriverApp.Shared;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        BindingContext = new AppShellViewModel();

        #region Routing
        Routing.RegisterRoute(nameof(AppShell), typeof(AppShell));
        Routing.RegisterRoute(nameof(RegisterPage), typeof(RegisterPage));
        Routing.RegisterRoute(nameof(ConfirmRegisterPage), typeof(ConfirmRegisterPage));
        Routing.RegisterRoute(nameof(ProceedRegisterPage), typeof(ProceedRegisterPage));
        Routing.RegisterRoute(nameof(CreateCarPage), typeof(CreateCarPage));
        Routing.RegisterRoute(nameof(CreateRoutePage), typeof(CreateRoutePage));    
        Routing.RegisterRoute(nameof(RoutePage), typeof(RoutePage));
        Routing.RegisterRoute(nameof(OnReviewOrdersPage), typeof(OnReviewOrdersPage));
        Routing.RegisterRoute(nameof(DetailOrderPage), typeof(DetailOrderPage));
        Routing.RegisterRoute(nameof(ActiveOrdersPage), typeof(ActiveOrdersPage));
        #endregion
    }
}
