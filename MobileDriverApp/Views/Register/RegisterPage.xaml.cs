using MobileDriverApp.ViewModels.Register;

namespace MobileDriverApp.Views.Register;

public partial class RegisterPage : ContentPage
{
	public RegisterPage(RegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}