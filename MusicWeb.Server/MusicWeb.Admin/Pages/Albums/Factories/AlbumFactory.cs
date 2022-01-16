using AutoMapper;
using MusicWeb.Admin.Pages.Albums.Factories.Interfaces;
using MusicWeb.Admin.Pages.Albums.Models;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Factories
{
    public class AlbumFactory : IAlbumFactory
    {
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;

        public AlbumFactory(IAlbumService albumService,
                            ISongService songService,
                            IMapper mapper,
                            IArtistService artistService, 
                            IGenreService genreService)
        {
            _albumService = albumService;
            _songService = songService;
            _mapper = mapper;
            _artistService = artistService;
            _genreService = genreService;
        }

        public async Task PrepareCreator(List<ArtistSelectModel> artists, List<GenreSelectModel> genres)
        {
            artists.AddRange(_mapper.Map<List<ArtistSelectModel>>(await _artistService.GetAllAsync()));
            genres.AddRange(_mapper.Map<List<GenreSelectModel>>(await _genreService.GetAllAsync()));
        }

        public async Task<List<AlbumPageModel>> PrepareAlbums(int filter)
        {
            return _mapper.Map<List<AlbumPageModel>>(await _albumService.GetAllFilteredAsync(filter));
        }

        public async Task PrepareSongs(AlbumPageModel model)
        {
            model.SongList = _mapper.Map<List<SongPageModel>>(await _songService.GetAllAsync());
        }
    }
}
