namespace Solar_Power_Lookup_Maui;

public partial class SolarDetailsPage : ContentPage
{
	public SolarDetailsPage(SolarDetailsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}