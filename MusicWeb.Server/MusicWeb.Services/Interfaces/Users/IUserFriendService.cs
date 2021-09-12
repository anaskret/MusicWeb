using MusicWeb.Models.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserFriendService
    {
        Task CreateAsync(UserFriendDto entity);
        Task DeleteAsync(int id);
        Task<List<UserFriendDto>> GetAllAsync();
        Task<UserFriendDto> GetByIdAsync(int id);
    }
}
