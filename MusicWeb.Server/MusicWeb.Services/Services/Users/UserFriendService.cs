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

        public async Task CreateAsync(UserFriend entity)
        {
            await _userFriendRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userFriendRepository.GetByIdAsync(id);
            await _userFriendRepository.DeleteAsync(entity);
        }

        public async Task<List<UserFriend>> GetAllAsync()
        {
            return await _userFriendRepository.GetAllAsync();
        }

        public async Task<UserFriend> GetByIdAsync(int id)
        {
            return await _userFriendRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UserFriend entity)
        {
            await _userFriendRepository.UpdateAsync(entity);
        }
    }
}
