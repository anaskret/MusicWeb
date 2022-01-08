using MusicWeb.Models.Entities.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Ratings
{
    public interface IArtistRatingService
    {
        Task AddAsync(ArtistRating entity);
        Task UpdateAsync(ArtistRating entity);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<ArtistRating>> GetAllByArtistIdAsync(int id);
        Task<IList<ArtistRating>> GetAllByUserIdAsync(string id);
        Task<ArtistRating> GetByIdAsync(int id);
        Task<ArtistRating> GetUserRating(int id, string userId);
    }
}
