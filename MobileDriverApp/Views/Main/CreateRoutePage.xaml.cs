using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class CreateRoutePage : ContentPage
{
	public CreateRoutePage(CreateRouteTripViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}