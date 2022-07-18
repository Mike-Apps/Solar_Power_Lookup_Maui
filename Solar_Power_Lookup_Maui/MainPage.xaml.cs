namespace Solar_Power_Lookup_Maui;

public partial class MainPage : ContentPage
{
   

    public MainPage(SolarDataMain viewmodel)
    {
        InitializeComponent();
        BindingContext = viewmodel;
        viewmodel.GetStatesCommand.Execute(this);

        
    }

    
}

