using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class KitPage : ContentPage
{
	public KitPage(KitViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;
	}
}