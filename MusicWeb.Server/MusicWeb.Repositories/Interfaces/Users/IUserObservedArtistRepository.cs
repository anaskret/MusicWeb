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
    public interface IUserObservedArtistRepository : IRepository<UserObservedArtist>
    {
        Task<List<UserObservedArtist>> GetAllWithArtistByUserIdAsync(string userId);
        Task<List<ArtistRatingAverage>> GetFavoriteArtistData(string userId, int pageNum = 0, int pageSize = 15);
    }
}
