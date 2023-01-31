using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class CreateCarPage : ContentPage
{
	public CreateCarPage(CreateCarViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}