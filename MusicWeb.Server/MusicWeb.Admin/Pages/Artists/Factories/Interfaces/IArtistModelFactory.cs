using MusicWeb.Models.Models.Artists;
using MusicWeb.Models.Models.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Artists.Factories.Interfaces
{
    public interface IArtistModelFactory
    {
        Task PrepareCreator(List<CountryModel> countries, List<StateModel> states, List<CityModel> cities, List<BandModel> bands);
    }
}
