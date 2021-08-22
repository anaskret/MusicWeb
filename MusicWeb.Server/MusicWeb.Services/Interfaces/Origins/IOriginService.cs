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
        Task AddStateAsync(State entity);
        Task AddCityAsync(City entity);
    }
}
