using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Users
{
    public interface IUserFavoriteAlbumRepository : IRepository<UserFavoriteAlbum>
    {
        Task<List<UserFavoriteAlbum>> GetAllWithAlbumByUserIdAsync(string userId);
        Task<List<AlbumRatingAverage>> GetFavoriteAlbumData(string userId);
    }
}
