using AutoMapper;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Users
{
    public class UserFavoriteAlbumService : IUserFavoriteAlbumService
    {
        private readonly IUserFavoriteAlbumRepository _userFavoriteAlbumRepository;
        private readonly IMapper _mapper;
        public UserFavoriteAlbumService(IUserFavoriteAlbumRepository userFavoriteAlbumRepository, IMapper mapper)
        {
            _userFavoriteAlbumRepository = userFavoriteAlbumRepository;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userFavoriteAlbumRepository.GetByIdAsync(id);
            await _userFavoriteAlbumRepository.DeleteAsync(entity);
        }

        public async Task<IList<UserFavoriteAlbum>> GetAllByUserIdAsync(string userId)
        {
            return await _userFavoriteAlbumRepository.GetAllWithAlbumByUserIdAsync(userId);

        }

        public async Task<IList<UserFavoriteAlbum>> GetUserFavoriteAlbumAsync(string userId, int albumId)
        {
            var models = await _userFavoriteAlbumRepository.GetAllWithAlbumByUserIdAsync(userId);
            return models;
        }

        public async Task CreateAsync(UserFavoriteAlbum entity)
        {
            await _userFavoriteAlbumRepository.AddAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _userFavoriteAlbumRepository.DeleteRangeAsync(entities.ToList());
        }
    }
}
