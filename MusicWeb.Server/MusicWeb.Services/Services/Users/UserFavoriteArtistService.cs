using AutoMapper;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Users
{
    public class UserFavoriteArtistService : IUserFavoriteArtistService
    {
        private readonly IUserFavoriteArtistRepository _userFavoriteArtistRepository;
        private readonly IMapper _mapper;
        public UserFavoriteArtistService(IMapper mapper, IUserFavoriteArtistRepository userFavoriteArtistRepository)
        {
            _mapper = mapper;
            _userFavoriteArtistRepository = userFavoriteArtistRepository;
        }

        public async Task CreateAsync(UserFavoriteDto model)
        {
            var entity = _mapper.Map<UserFavoriteArtist>(model);
            await _userFavoriteArtistRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userFavoriteArtistRepository.GetByIdAsync(id);
            await _userFavoriteArtistRepository.DeleteAsync(entity);
        }

        public async Task<IList<UserFavoriteArtist>> GetAllByUserIdAsync(string userId)
        {
            return await _userFavoriteArtistRepository.GetAllWithArtistByUserIdAsync(userId);
        }

        public async Task<IList<UserFavoriteArtist>> GetUserFavoriteArtistAsync(string userId, int artistId)
        {
            var models = await _userFavoriteArtistRepository.GetAllWithArtistByUserIdAsync(userId);
            return models;
        }

        public async Task CreateAsync(UserFavoriteArtist entity)
        {
            await _userFavoriteArtistRepository.AddAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _userFavoriteArtistRepository.DeleteRangeAsync(entities.ToList());
        }

        public async Task<List<ArtistRatingAverage>> GetFavoriteArtistDataAsync(string userId)
        {
            var response = await _userFavoriteArtistRepository.GetFavoriteArtistData(userId);
            return response;
        }

    }
}
