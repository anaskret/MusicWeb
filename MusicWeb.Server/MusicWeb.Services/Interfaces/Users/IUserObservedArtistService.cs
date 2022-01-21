using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserObservedArtistService
    {
        Task<IList<UserObservedArtist>> GetAllByUserIdAsync(string userId);
        Task CreateAsync(UserObservedArtist model);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<UserObservedArtist>> GetUserObservedArtistAsync(string userId, int artistId);
        Task<List<ArtistRatingAverage>> GetFavoriteArtistDataAsync(string userId);
    }
}
