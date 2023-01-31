using Microsoft.AspNetCore.SignalR.Client;
using MobileDriverApp.Models;
using MobileDriverApp.Services;
using MobileDriverApp.ViewModels.Main;
using System.Text.Json;

namespace MobileDriverApp.Views.Main;

public partial class HistoryOrderPage : ContentPage
{
	public HistoryOrderPage(HistoryOrderViewModel model)
	{
		InitializeComponent();
		this.BindingContext = model;

	}


}