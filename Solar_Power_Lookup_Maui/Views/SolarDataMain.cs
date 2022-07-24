
/* Unmerged change from project 'Solar_Power_Lookup_Maui (net6.0-windows10.0.19041.0)'
Before:
using System.Collections.ObjectModel;
using Solar_Power_Lookup_Maui.Model;
After:
using Solar_Power_Lookup_Maui.Model;
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'Solar_Power_Lookup_Maui (net6.0-maccatalyst)'
Before:
using System.Collections.ObjectModel;
using Solar_Power_Lookup_Maui.Model;
After:
using Solar_Power_Lookup_Maui.Model;
using System.Collections.ObjectModel;
*/

/* Unmerged change from project 'Solar_Power_Lookup_Maui (net6.0-ios)'
Before:
using System.Collections.ObjectModel;
using Solar_Power_Lookup_Maui.Model;
After:
using Solar_Power_Lookup_Maui.Model;
using System.Collections.ObjectModel;
*/
namespace Solar_Power_Lookup_Maui.Views
{
    public partial class SolarDataMain : BaseViewModel
    {
        //Create an observable collection of SolarModel that will viewed in the XAML.
        public ObservableCollection<SolarModel> solarmodel_observablecollection { get; } = new();
        public ObservableCollection<SolarModel> solarcity_observablecollection { get; } = new();

        SolarServices solarServices;
        SolarServices solarCity;

        public SolarDataMain(SolarServices solarServices, SolarServices solarCity)
        {
            this.solarServices = solarServices;
            this.solarCity = solarCity;
        }

        [ObservableProperty]
        bool isRefreshing;

        //explore JSON and populate states to solarmodel_observablecollection 
        [ICommand]
        async Task GetStatesAsync()
        {
            if (IsBusy)
                return;
            Dictionary<string, string> dict = new Dictionary<string, string>();

            try
            {
                IsBusy = true;
                var solar = await solarServices.GetSolar();
                solar.Sort((p, q) => p.State.CompareTo(q.State));

                if (solarmodel_observablecollection.Count != 0)
                {
                    solarmodel_observablecollection.Clear();
                }

                foreach (var sol in solar)
                {
                    if (!dict.ContainsKey(sol.State))
                    {
                        dict.Add(sol.State, sol.State);
                        solarmodel_observablecollection.Add(sol);

                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;


            }
        }



        //If you click on a state, the following will return the city that is associated with the state
        //populate the solarcity_observablecollection with the respective states.
        [ICommand]
        async Task GetCityAsync(SolarModel solarModel)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                var solarCity = await solarServices.GetSolar();
                solarCity.Sort((p, q) => p.City.CompareTo(q.City));

                if (solarcity_observablecollection.Count != 0)
                {
                    solarcity_observablecollection.Clear();
                }

                foreach (var solarObject in solarCity)
                {
                    if (solarObject.State == solarModel.State)
                    {
                        solarcity_observablecollection.Add(solarObject);
                    }
                }
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;

            }
        }

        //navigate to the details page and push the solarModel object to the details page.
        [ICommand]
        async Task GoToDetails(SolarModel solarModel)
        {
            if (solarModel == null)
            {
                return;
            }

            await Shell.Current.GoToAsync(nameof(SolarDetailsPage), true, new Dictionary<string, object> { { "SolarModel", solarModel } });
        }
    }
}
