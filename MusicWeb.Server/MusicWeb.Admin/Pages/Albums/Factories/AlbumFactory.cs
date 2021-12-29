using AutoMapper;
using MusicWeb.Admin.Pages.Albums.Factories.Interfaces;
using MusicWeb.Admin.Pages.Albums.Models;
using MusicWeb.Services.Interfaces;
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

        public AlbumFactory(IAlbumService albumService, 
                            ISongService songService, 
                            IMapper mapper)
        {
            _albumService = albumService;
            _songService = songService;
            _mapper = mapper;
        }

        public async Task<List<AlbumPageModel>> PrepareAlbums()
        {
            return _mapper.Map<List<AlbumPageModel>>(await _albumService.GetAllAsync());
        }

        public async Task PrepareSongs(AlbumPageModel model)
        {
            model.SongList = _mapper.Map<List<SongPageModel>>(await _songService.GetAllAsync());
        }
    }
}
