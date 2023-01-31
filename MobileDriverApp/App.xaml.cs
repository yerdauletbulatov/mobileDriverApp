using MobileDriverApp.Shared;

namespace MobileDriverApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        MainPage = new AppShell();
    }
}
