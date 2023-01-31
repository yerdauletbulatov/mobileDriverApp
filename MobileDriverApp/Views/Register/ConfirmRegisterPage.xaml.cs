using MobileDriverApp.ViewModels.Register;

namespace MobileDriverApp.Views.Register;

public partial class ConfirmRegisterPage : ContentPage
{
	public ConfirmRegisterPage(ConfirmRegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}