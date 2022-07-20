namespace Solar_Power_Lookup_Maui;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        //routing registration for xaml pages...
        Routing.RegisterRoute(nameof(SolarDetailsPage),typeof(SolarDetailsPage));
    }
}
