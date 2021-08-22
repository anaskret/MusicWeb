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
    }
}
