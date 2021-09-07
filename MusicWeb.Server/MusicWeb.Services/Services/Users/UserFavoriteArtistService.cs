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

        public async Task<List<UserFavoriteDto>> GetAllAsync()
        {
            var entites = await _userFavoriteArtistRepository.GetAllWithArtistAsync();
            return _mapper.Map<List<UserFavoriteDto>>(entites);
        }
    }
}
