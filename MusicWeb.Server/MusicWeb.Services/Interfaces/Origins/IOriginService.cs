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
        Task AddCountriesRangeAsync(List<Country> entities);
        Task UpdateCountryAsync(Country entity);
        Task DeleteCountryAsync(int id);
        Task<Country> GetCountryByIdAsync(int id);
        Task<IList<Country>> GetAllCountriesAsync();

    }
}
