using AutoMapper;
using MusicWeb.Admin.Pages.Artists.Factories.Interfaces;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Models.Models.Origins;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Artists.Factories
{
    public class ArtistModelFactory : IArtistModelFactory
    {
        private readonly IOriginService _originService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistModelFactory(IOriginService originService, IArtistService artistService, IMapper mapper)
        {
            _originService = originService;
            _artistService = artistService;
            _mapper = mapper;
        }

        public Task PrepareCreator(List<CountryModel> countries, List<StateModel> states, List<CityModel> cities, List<BandModel> bands)
        {
            throw new NotImplementedException();
        }
    }
}
