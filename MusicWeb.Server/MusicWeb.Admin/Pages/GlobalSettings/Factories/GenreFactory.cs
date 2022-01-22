using AutoMapper;
using MusicWeb.Admin.Pages.GlobalSettings.Factories.Interfaces;
using MusicWeb.Admin.Pages.GlobalSettings.Models;
using MusicWeb.Services.Interfaces.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.GlobalSettings.Factories
{
    public class GenreFactory : IGenreFactory
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreFactory(IGenreService genreService, 
                            IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        public async Task PrepareList(List<GenrePageModel> list)
        {
            list.AddRange(_mapper.Map<List<GenrePageModel>>(await _genreService.GetAllAsync()));
        }

        public async Task<GenrePageModel> PrepareModel(int id)
        {
            return _mapper.Map<GenrePageModel>(await _genreService.GetByIdAsync(id));
        }
    }
}
