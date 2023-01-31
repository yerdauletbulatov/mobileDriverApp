using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class SupportServicePage : ContentPage
{
	public SupportServicePage(SupportServiceViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}