using AutoMapper;
using Microsoft.Extensions.Configuration;
using MusicWeb.Admin.Models;
using MusicWeb.Admin.Pages.Artists.Factories.Interfaces;
using MusicWeb.Admin.Pages.Artists.Models;
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
        private readonly IConfiguration _configuration;

        public ArtistModelFactory(IOriginService originService, IArtistService artistService, IMapper mapper, IConfiguration configuration)
        {
            _originService = originService;
            _artistService = artistService;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task PrepareCreator(List<CountryModel> countries, List<StateModel> states, List<CityModel> cities, List<BandModel> bands)
        {
            countries.AddRange(_mapper.Map<List<CountryModel>>(await _originService.GetAllCountriesAsync()));
            states.AddRange(_mapper.Map<List<StateModel>>(await _originService.GetAllStatesAsync()));
            cities.AddRange(_mapper.Map<List<CityModel>>(await _originService.GetAllCitiesAsync()));
            bands.AddRange(_mapper.Map<List<BandModel>>(await _artistService.GetAllBandsAsync()));
        }

        public async Task<EditArtistModel> PrepareEdit(int id)
        {
            var model = _mapper.Map<EditArtistModel>(await _artistService.GetByIdAsync(id));
            var city = await _originService.GetCityByIdAsync(model.CityId);
            var state = await _originService.GetStateByIdAsync(city.StateId);

            model.StateId = state.Id;
            model.CountryId = state.CountryId;

            return model;
        }

        public async Task PrepareList(List<ArtistModel> list, PagerModel pager)
        {
            if (pager.PageIndex > 0)
                pager.PageIndex = pager.PageIndex - 1;
            var pageSize = _configuration.GetValue<int>("Settings:PageSize");

            var pagedList = await _artistService.GetIPagedAsync(pager.SearchString, pager.PageIndex, pageSize);
            list.AddRange(_mapper.Map<List<ArtistModel>>(pagedList.ToList()));

            pager.PageSize = pagedList.PageSize;
            pager.TotalRecords = pagedList.TotalCount;
            pager.PageIndex = pagedList.PageIndex;
            pager.UrlAdress = "/artists/list";
        }
    }
}
