﻿using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserFriendService
    {
        Task CreateAsync(UserFriend entity);
        Task CreateNewRequestAsync(UserFriend entity);
        Task DeleteAsync(string userId, string friendId);
        Task DeleteRangeByUserIdAsync(string userId);
        Task UpdateAsync(UserFriend entity);
        Task<UserFriend> GetSingleByUserIdAndFriendIdAsync(string userId, string friendId);
        Task<IList<UserFriend>> GetAllByUserIdAsync(string userId);
        Task<UserFriend> GetByIdAsync(int id);
        Task AcceptFriendRequestAsync(UserFriend entity);
    }
}
