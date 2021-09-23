using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Origins
{
    public interface IOriginService
    {
        Task AddCountryAsync(Country entity);
        Task UpdateCountryAsync(Country entity);
        Task DeleteCountryAsync(int id);
        Task<Country> GetCountryByIdAsync(int id);
        Task<List<Country>> GetAllCountriesAsync();
        Task<List<State>> GetStatesByCountryAsync(int id);

        Task AddStateAsync(State entity);
        Task UpdateStateAsync(State entity);
        Task DeleteStatesRangeAsync(List<State>entities);
        Task DeleteStateAsync(int id);
        Task<State> GetStateByIdAsync(int id);
        Task<List<State>> GetAllStatesAsync();
        Task<List<City>> GetCitiesByStateAsync(int id);

        Task AddCityAsync(City entity);
        Task UpdateCityAsync(City entity);
        Task DeleteCityAsync(int id);
        Task DeleteCitiesRangeAsync(List<City> entities);
        Task<City> GetCityByIdAsync(int id);
        Task<List<City>> GetAllCitiesAsync();

    }
}
