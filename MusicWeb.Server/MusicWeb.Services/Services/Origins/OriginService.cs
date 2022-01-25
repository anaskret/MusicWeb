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

        public OriginService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task AddCountryAsync(Country entity)
        {
            await _countryRepository.AddAsync(entity);
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

        public async Task AddCountriesRangeAsync(List<Country> entities)
        {
            await _countryRepository.AddRangeAsync(entities);
        }

        public async Task<Country> GetCountryByCodeAsync(string code)
        {
            return await _countryRepository.GetSingleAsync(prp => string.Equals(prp.Code, code));
        }
    }
}
