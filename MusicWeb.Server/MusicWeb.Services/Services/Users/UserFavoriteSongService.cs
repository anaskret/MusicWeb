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

        public async Task CreateAsync(UserFavoriteDto model)
        {
            var entity = _mapper.Map<UserFavoriteSong>(model);
            await _userFavoriteSongRepository.AddAsync(entity);
        }

        public async Task<List<UserFavoriteDto>> GetAllAsync()
        {
            var entites = await _userFavoriteSongRepository.GetAllWithSongAsync();
            return _mapper.Map<List<UserFavoriteDto>>(entites);
        }
    }
}
