using AutoMapper;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllAsync()
        {
            return _mapper.Map<List<UserDto>>(await _userRepository.GetAllAsync());
        }

        public async Task<UserDto> GetUserProfileById(string id)
        {
            var entity = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(entity);
        }
    }
}
