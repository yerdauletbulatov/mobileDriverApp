using MobileDriverApp.Models.Values;
using MobileDriverApp.ViewModels;
using MobileDriverApp.ViewModels.Main;

namespace MobileDriverApp.Views.Main;

public partial class OnReviewOrdersPage : ContentPage
{
    private readonly DetailOrderViewModel _viewModel;
    public OnReviewOrdersPage(OnReviewOrdersViewModel model, DetailOrderViewModel detailOrderViewModel)
	{
		InitializeComponent();
		BindingContext = model;
		_viewModel = detailOrderViewModel;
        OnReviewOrders.Appearing += model.ContentPage_Appearing;
    }
    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        var clientPackageinfo = e.Item as OrderInfo;
        if (clientPackageinfo is not null)
        {
            _viewModel.OrderInfo = clientPackageinfo;
            await Navigation.PushAsync(new DetailOrderPage(_viewModel));
        }
    }
}