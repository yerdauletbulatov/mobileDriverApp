using MobileDriverApp.ViewModels;
using OpenMap = Microsoft.Maui.ApplicationModel.Map;

namespace MobileDriverApp.Views.Main;

public partial class DetailOrderPage : ContentPage
{
	private readonly DetailOrderViewModel _model;
    public DetailOrderPage(DetailOrderViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		_model = viewModel;

    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var location = new Location(_model.OrderInfo.Location.Latitude, _model.OrderInfo.Location.Longitude);
		await OpenMap.TryOpenAsync(location, new MapLaunchOptions
		{
			Name = _model.OrderInfo.ClientName,
			NavigationMode = NavigationMode.Driving
		});
	}
}