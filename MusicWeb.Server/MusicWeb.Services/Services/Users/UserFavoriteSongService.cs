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
    public class UserFavoriteSongService : IUserFavoriteSongService
    {
        private readonly IUserFavoriteSongRepository _userFavoriteSongRepository;
        private readonly IMapper _mapper;
        public UserFavoriteSongService(IMapper mapper, IUserFavoriteSongRepository userFavoriteSongRepository)
        {
            _mapper = mapper;
            _userFavoriteSongRepository = userFavoriteSongRepository;
        }

        public async Task CreateAsync(UserFavoriteSong entity)
        {
            await _userFavoriteSongRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userFavoriteSongRepository.GetByIdAsync(id);
            await _userFavoriteSongRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _userFavoriteSongRepository.DeleteRangeAsync(entities.ToList());
        }

        public async Task<IList<UserFavoriteSong>> GetAllByUserIdAsync(string userId)
        {
            return await _userFavoriteSongRepository.GetAllWithSongByUserIdAsync(userId);
        }
    }
}
