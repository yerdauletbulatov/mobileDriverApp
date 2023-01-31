using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class RoutePage : ContentPage
{
	public RoutePage(RouteViewModel model)
	{
        InitializeComponent();
		this.BindingContext = model;
        RouteTripPage.Appearing += model.ContentPage_Appearing;
    }
}