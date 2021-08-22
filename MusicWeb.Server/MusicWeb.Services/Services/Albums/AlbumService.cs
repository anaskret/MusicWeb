using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;

        public AlbumService(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task AddAsync(Album entity)
        {
            await _albumRepository.AddAsync(entity);
        }
    }
}
