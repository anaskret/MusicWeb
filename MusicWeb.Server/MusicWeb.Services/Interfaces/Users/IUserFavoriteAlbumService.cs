using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserFavoriteAlbumService
    {
        Task<IList<UserFavoriteAlbum>> GetAllByUserIdAsync(string userId);
        Task CreateAsync(UserFavoriteAlbum entity);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<UserFavoriteAlbum>> GetUserFavoriteAlbumAsync(string userId, int albumId);
        Task<List<AlbumRatingAverage>> GetFavoriteAlbumDataAsync(string userId, int pageNum = 0, int pageSize = 15);
    }
}
