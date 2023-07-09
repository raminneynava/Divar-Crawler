using Divar_Crawler.DTOs;
using Newtonsoft.Json;

namespace Divar_Crawler.Services
{
    public class CitiesService
    {
        private string _citiesJsonPath;

        public CitiesService(string citiesJsonPath)
        {
            _citiesJsonPath = citiesJsonPath;
        }

        // Read the JSON file containing cities and deserialize it into a list of CityDto objects
        public async Task<List<CityDto>> ReadCityJsonFile()
        {
            string json = await File.ReadAllTextAsync(_citiesJsonPath);
            return JsonConvert.DeserializeObject<List<CityDto>>(json.ToLower().Replace(" ", ""));
        }
    }
}
