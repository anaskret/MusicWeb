using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserFavoriteSongService 
    {
        Task<IList<UserFavoriteSong>> GetAllByUserIdAsync(string userId);
        Task CreateAsync(UserFavoriteSong entity);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<UserFavoriteSong>> GetUserFavoriteSongAsync(string userId, int songId);

    }
}
