using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Hubs;
using MusicWeb.Services.Interfaces.Hubs;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHubContext<FriendsHub, IFriendsHub> _hubContext;

        public UserFriendService(IUserFriendRepository userFriendRepository,
            IMapper mapper,
            IHubContext<FriendsHub, IFriendsHub> hubContext, 
            UserManager<ApplicationUser> userManager)
        {
            _userFriendRepository = userFriendRepository;
            _mapper = mapper;
            _hubContext = hubContext;
            _userManager = userManager;
        }

        public async Task CreateNewRequestAsync(UserFriend entity)
        {
            var doesExist = await _userFriendRepository.GetSingleAsync(prp => (string.Equals(prp.UserId, entity.UserId) && string.Equals(prp.FriendId, entity.FriendId))
                                                                           || (string.Equals(prp.FriendId, entity.UserId) && string.Equals(prp.UserId, entity.FriendId)));
            if (doesExist != null)
                throw new ArgumentException("You already have that user in your friend list or the invite is already sent");

            entity.CreatedByUserId = entity.UserId;

            await CreateAsync(entity);

            var user = await _userManager.FindByIdAsync(entity.UserId);
            if (user == null)
                throw new Exception("Friend Request was created, but notification was not sent as user was not found");

            var fullName = user.FirstName + " " + user.LastName;
            await _hubContext.Clients.All.SendFriendRequest(entity.UserId, entity.FriendId, fullName);
        }

        public async Task AcceptFriendRequestAsync(UserFriend entity)
        {
            var sender = await GetSingleByUserIdAndFriendIdAsync(entity.FriendId, entity.UserId);
            if (sender == null)
                throw new ArgumentException("UserFriendRequest with this userId and friendId doesn't exist");
            if (sender.IsAccepted)
                throw new ArgumentException("UserFriendRequest is already accepted");

            sender.IsAccepted = true;

            await UpdateAsync(sender);

            await _hubContext.Clients.Group(sender.UserId).FriendRequestAccepted(sender.UserId, sender.FriendId);
        }

        public async Task CreateAsync(UserFriend entity)
        {
            await _userFriendRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(string userId, string friendId)
        {
            var entity = await _userFriendRepository.GetSingleAsync(prp => string.Equals(prp.UserId, userId) && string.Equals(prp.FriendId, friendId)
                                                                        || string.Equals(prp.FriendId, userId) && string.Equals(prp.UserId, friendId));

            if(entity != null)
                await _userFriendRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _userFriendRepository.DeleteRangeAsync(entities.ToList());
        }

        public async Task<IList<UserFriend>> GetAllAsync()
        {
            return await _userFriendRepository.GetAllAsync();
        }

        public async Task<IList<UserFriend>> GetAllByUserIdAsync(string userId)
        {
            return await _userFriendRepository.GetAllAsync(entity => entity.Where(prp => string.Equals(prp.UserId, userId)
                                                                  || string.Equals(prp.FriendId, userId))
                                                                           .Include(prp => prp.Friend)
                                                                           .Include(prp => prp.User));
        }

        public async Task<UserFriend> GetByIdAsync(int id)
        {
            return await _userFriendRepository.GetByIdAsync(id);
        }

        public async Task<UserFriend> GetSingleByUserIdAndFriendIdAsync(string userId, string friendId)
        {
            return await _userFriendRepository.GetUserFriendByIdsWithFriendDataAsync(userId, friendId);
        }

        public async Task UpdateAsync(UserFriend entity)
        {
            await _userFriendRepository.UpdateAsync(entity);
        }
    }
}
