using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Posts;
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
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ISongService _songService;

        public AlbumService(IAlbumRepository albumRepository,
                            IMapper mapper,
                            IPostService postService, 
                            ISongService songService)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _postService = postService;
            _songService = songService;
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _albumRepository.GetByIdNoTrackingAsync(id);
        }

        public async Task<List<Album>> GetAllAsync()
        {
            var entites = await _albumRepository.GetAllAsync(obj => obj.Where(prp => prp.IsConfirmed).AsNoTracking());
            return entites.ToList();
        }

        public async Task<List<Album>> GetAllUnconfirmedAsync()
        {
            var entites = await _albumRepository.GetAllAsync(obj => obj.Where(prp => !prp.IsConfirmed).Include(prp => prp.Artist).Include(prp => prp.AlbumGenre));
            return entites.ToList();
        }

        public async Task AddAsync(Album entity)
        {
            await _albumRepository.AddAsync(entity);

            await _postService.AddAsync(new Post { AlbumId = entity.Id, ArtistPosterId = entity.ArtistId, CreateDate = DateTime.Now });
        }

        public async Task UpdateAsync(Album entity)
        {
            await _albumRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var songEntities = await _songService.GetSongsByAlbumIdAsync(id);
            await _songService.DeleteRangeAsync(songEntities);

            var entity = await GetByIdAsync(id);
            await _albumRepository.DeleteAsync(entity);
        }

        public async Task ConfirmAlbumAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsConfirmed = true;

            await _albumRepository.DeleteAsync(entity);
        }

        public async Task<AlbumFullDataDto> GetFullAlbumDataByIdAsync(int id)
        {
            var album = await _albumRepository.GetFullAlbumDataByIdAsync(id);
            return _mapper.Map<AlbumFullDataDto>(album);
        }

        public async Task<List<Album>> GetUnconfirmedAlbumsAsync()
        {
            var entities = await _albumRepository.GetAllAsync(obj => obj.Where(prp => prp.IsConfirmed));
            return entities.ToList();
        }

        public async Task<AlbumRatingAverage> GetAlbumRatingAverage(int id)
        {
            return _mapper.Map<AlbumRatingAverage>(await _albumRepository.GetAlbumAverageRating(id));
        }


    }
}
