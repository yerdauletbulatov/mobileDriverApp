using MobileDriverApp.Models.Values;

namespace MobileDriverApp.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
    public FlyoutHeaderControl()
    {
        InitializeComponent();
        UserName.Text = Preferences.Get(nameof(DriverInfo.Name), string.Empty);
        UserSurname.Text = Preferences.Get(nameof(DriverInfo.Surname), string.Empty);
        UserPhoneNumber.Text = Preferences.Get(nameof(DriverInfo.PhoneNumber), string.Empty);
    }
}


