using System.ComponentModel;

namespace Solar_Power_Lookup_Maui.Views
{
    [QueryProperty(nameof(SolarModel), "SolarModel")]
    public partial class SolarDetailsViewModel : BaseViewModel 
    {

        public SolarDetailsViewModel()
        {

        }

        [ObservableProperty]
        SolarModel solarModel;

        //optional Back Button Command

        [ICommand]
        async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
            //await Shell.Current.GoToAsync("../.."); goes back two pages
            //await Shell.Current.GoToAsync("../MainPage"); goes back the mainpage

        }

    }
}
