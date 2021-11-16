using MusicWeb.Models.Dtos.Users;
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
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task UpdateAsync(UserFriend entity);
        Task<IList<UserFriend>> GetAllByUserIdAsync(string userId);
        Task<UserFriend> GetByIdAsync(int id);
        Task AcceptFriendRequestAsync(UserFriend entity);
    }
}
