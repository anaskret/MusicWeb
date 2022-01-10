using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Ratings
{
    public interface IArtistRatingRepository : IRepository<ArtistRating>
    {
        Task<IList<ArtistRating>> GetUserRating(int id, string userId);
    }
}
