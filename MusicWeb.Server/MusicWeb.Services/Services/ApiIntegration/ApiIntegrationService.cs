using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Responses.ApiIntegration;
using MusicWeb.Services.Interfaces.ApiIntegration;
using MusicWeb.Services.Interfaces.Origins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.ApiIntegration
{
    public class ApiIntegrationService : IApiIntegrationService
    {
        private readonly IOriginService _originService;

        public ApiIntegrationService(IOriginService originService)
        {
            _originService = originService;
        }

        public async Task IntegrateCountriesAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage 
            { 
                Method = HttpMethod.Get, 
                RequestUri = new Uri("https://restcountries.com/v3.1/all")
            };

            var response = await client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<List<SingleCountry>>(await response.Content.ReadAsStringAsync());
            var localCountries = await _originService.GetAllCountriesAsync();

            var newCountries = new List<Country>();
            foreach(var item in result)
            {
                if (!localCountries.Any(prp => string.Equals(prp.Code, item.cca3)))
                    newCountries.Add(new Country { Name = item.name.common, Code = item.cca3 });
            }

            await _originService.AddCountriesRangeAsync(newCountries);
        }
    }
}
