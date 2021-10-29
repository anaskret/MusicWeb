using AutoMapper;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
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
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;


        public AlbumService(IAlbumRepository albumRepository, IMapper mapper, IArtistService artistService)
        {
            _albumRepository = albumRepository;
            _artistService = artistService;
            _mapper = mapper;
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _albumRepository.GetByIdAsync(id);
        }

        public async Task<List<AlbumDto>> GetAllAsync()
        {
            return _mapper.Map<List<AlbumDto>>(await _albumRepository.GetAllAsync());
        }

        public async Task AddAsync(Album entity)
        {
            await _albumRepository.AddAsync(entity);

           // var artistEntity = await GetByIdAsync(entity.Id.GetValueOrDefault());
            var artistEntity = await GetByIdAsync(entity.ArtistId);
            if (artistEntity == null)
                throw new ArgumentException("Incorrect ArtistId");
            


        }

        public async Task UpdateAsync(Album entity)
        {
            await _albumRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _albumRepository.DeleteAsync(entity);
        }

        public async Task<AlbumDto> GetFullAlbumDataByIdAsync(int id)
        {
            var album = await _albumRepository.GetFullAlbumDataByIdAsync(id);
            return _mapper.Map<AlbumDto>(album);
        }
    }
}
