using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Repositories.Interfaces.Origins;
using MusicWeb.Services.Interfaces.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Origins
{
    public class OriginService : IOriginService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IStateRepository _stateRepository;
        private readonly ICityRepository _cityRepository;

        public OriginService(ICountryRepository countryRepository, IStateRepository stateRepository, ICityRepository cityRepository)
        {
            _countryRepository = countryRepository;
            _stateRepository = stateRepository;
            _cityRepository = cityRepository;
        }

        public async Task AddCountryAsync(Country entity)
        {
            await _countryRepository.AddAsync(entity);
        }

        public async Task AddStateAsync(State entity)
        {
            await _stateRepository.AddAsync(entity);
        }
        
        public async Task AddCityAsync(City entity)
        {
            await _cityRepository.AddAsync(entity);
        }

        public async Task UpdateCountryAsync(Country entity)
        {
            await _countryRepository.UpdateAsync(entity);
        }

        public async Task DeleteCountryAsync(int id)
        {
            var entity = await GetCountryByIdAsync(id);
            if (entity == null)
                throw new ArgumentException($"Country with id {id} doesn't exist");

            var states = await GetStatesByCountryAsync(id);
            if (states.Count > 0)
                await DeleteStatesRangeAsync(states.ToList());

            await _countryRepository.DeleteAsync(entity);
        }

        public async Task<Country> GetCountryByIdAsync(int id)
        {
            return await _countryRepository.GetByIdAsync(id);
        }

        public async Task<IList<Country>> GetAllCountriesAsync()
        {
            return await _countryRepository.GetAllAsync();
        }

        public async Task<IList<State>> GetStatesByCountryAsync(int id)
        {
            var countryEntity = await GetCountryByIdAsync(id);
            if (countryEntity == null)
                throw new ArgumentException($"Country with id {id} doesn't exist");

            return await _stateRepository.GetAllAsync(entity => entity.Where(prp => prp.CountryId == id));
        }

        public async Task UpdateStateAsync(State entity)
        {
            await _stateRepository.UpdateAsync(entity);
        }

        public async Task DeleteStateAsync(int id)
        {
            var entity = await GetStateByIdAsync(id);
            if (entity == null)
                throw new ArgumentException($"State with id {id} doesn't exist");

            var cities = await GetCitiesByStateAsync(id);
            if(cities.Count > 0)
                await DeleteCitiesRangeAsync(cities.ToList());

            await _stateRepository.DeleteAsync(entity);
        }

        public async Task DeleteStatesRangeAsync(List<State> entities)
        {
            foreach(var entity in entities)
            {
                var cities = await GetCitiesByStateAsync(entity.Id);
                if (cities.Count > 0)
                    await DeleteCitiesRangeAsync(cities.ToList());
            }

            await _stateRepository.DeleteRangeAsync(entities);
        }

        public async Task<State> GetStateByIdAsync(int id)
        {
            return await _stateRepository.GetByIdAsync(id);
        }

        public async Task<IList<State>> GetAllStatesAsync()
        {
            return await _stateRepository.GetAllAsync();
        }

        public async Task<IList<City>> GetCitiesByStateAsync(int id)
        {
            var stateEntity = await GetStateByIdAsync(id);
            if (stateEntity == null)
                throw new ArgumentException($"State with id {id} doesn't exist");

            return await _cityRepository.GetAllAsync(entity => entity.Where(prp => prp.StateId == id));
        }

        public async Task UpdateCityAsync(City entity)
        {
            await _cityRepository.UpdateAsync(entity);
        }

        public async Task DeleteCityAsync(int id)
        {
            var entity = await GetCityByIdAsync(id);
            if (entity == null)
                throw new ArgumentException($"City with id {id} doesn't exist");

            await _cityRepository.DeleteAsync(entity);
        }

        public async Task DeleteCitiesRangeAsync(List<City> entites)
        {
            await _cityRepository.DeleteRangeAsync(entites);
        }

        public async Task<City> GetCityByIdAsync(int id)
        {
            return await _cityRepository.GetByIdAsync(id);
        }

        public async Task<IList<City>> GetAllCitiesAsync()
        {
            return await _cityRepository.GetAllAsync();
        }
    }
}
