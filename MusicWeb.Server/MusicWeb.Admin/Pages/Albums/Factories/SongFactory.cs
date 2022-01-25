using AutoMapper;
using MusicWeb.Admin.Pages.Albums.Factories.Interfaces;
using MusicWeb.Admin.Pages.Albums.Models;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Factories
{
    public class SongFactory : ISongFactory
    {
        private readonly ISongService _songService;
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public SongFactory(ISongService songService, 
                           IArtistService artistService, 
                           IMapper mapper)
        {
            _songService = songService;
            _artistService = artistService;
            _mapper = mapper;
        }

        public async Task<CreatorSongModel> PrepareEdit(int songId, List<ArtistSelectModel> composers)
        {
            composers.AddRange(_mapper.Map<List<ArtistSelectModel>>(await _artistService.GetAllAsync()));

            var song = await _songService.GetByIdAsync(songId);
            return _mapper.Map<CreatorSongModel>(song);
        }
    }
}
