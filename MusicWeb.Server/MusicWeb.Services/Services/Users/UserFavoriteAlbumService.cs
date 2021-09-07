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

        public async Task CreateAsync(UserFavoriteDto model)
        {
            var entity = _mapper.Map<UserFavoriteAlbum>(model);
            await _userFavoriteAlbumRepository.AddAsync(entity);
        }

        public async Task<List<UserFavoriteDto>> GetAllAsync()
        {
            var entites = await _userFavoriteAlbumRepository.GetAllWithAlbumAsync();
            return _mapper.Map<List<UserFavoriteDto>>(entites);
        }
    }
}
