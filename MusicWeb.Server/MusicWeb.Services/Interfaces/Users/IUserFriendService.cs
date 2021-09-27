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
        Task DeleteAsync(int id);
        Task UpdateAsync(UserFriend entity);
        Task<List<UserFriend>> GetAllAsync();
        Task<UserFriend> GetByIdAsync(int id);
    }
}
