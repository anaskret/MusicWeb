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
    public class UserFriendService : IUserFriendService
    {
        private readonly IUserFriendRepository _userFriendRepository;
        private readonly IMapper _mapper;

        public UserFriendService(IUserFriendRepository userFriendRepository, IMapper mapper)
        {
            _userFriendRepository = userFriendRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(UserFriendDto model)
        {
            var entity = _mapper.Map<UserFriend>(model);
            await _userFriendRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userFriendRepository.GetByIdAsync(id);
            await _userFriendRepository.DeleteAsync(entity);
        }

        public async Task<List<UserFriendDto>> GetAllAsync()
        {
            return _mapper.Map<List<UserFriendDto>>(await _userFriendRepository.GetAllAsync());
        }

        public async Task<UserFriendDto> GetByIdAsync(int id)
        {
            return _mapper.Map<UserFriendDto>(await _userFriendRepository.GetByIdAsync(id));
        }
    }
}
