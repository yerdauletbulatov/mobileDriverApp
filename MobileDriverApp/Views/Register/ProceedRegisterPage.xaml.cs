using MobileDriverApp.ViewModels.Register;

namespace MobileDriverApp.Views.Register;

public partial class ProceedRegisterPage : ContentPage
{
	public ProceedRegisterPage(ProceedRegisterViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}