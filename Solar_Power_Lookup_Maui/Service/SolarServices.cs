using System.Text.Json;

namespace Solar_Power_Lookup_Maui.Service
{
    //Use if I need to retrieve something Online
    // HttpClient httpClient;

    public class SolarServices
    {
        HttpClient httpClient;
        public SolarServices()
        {
            this.httpClient = new HttpClient();
        }


        List<SolarModel> solarModels;
        public async Task<List<SolarModel>> GetSolar()
        {
            if (solarModels?.Count > 0)
            {
                return solarModels;
            }

            // Online
            //var response = await httpClient.GetAsync("https://www.somelinkehere/somedatafile.json");
            //if (response.IsSuccessStatusCode)
            //{
            //    cigarmodel = await response.Content.ReadFromJsonAsync<List<CigarModel>>();
            //}

            // Offline
            using var stream = await FileSystem.OpenAppPackageFileAsync("solardata.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            solarModels = JsonSerializer.Deserialize<List<SolarModel>>(contents);

            return solarModels;

        }
    }
}

