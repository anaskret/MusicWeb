using MusicWeb.Models.Entities.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Ratings
{
    public interface ISongRatingService
    {
        Task AddAsync(SongRating entity);
        Task UpdateAsync(SongRating entity);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<SongRating>> GetAllBySongIdAsync(int id);
        Task<IList<SongRating>> GetAllByUserIdAsync(string id);
        Task<SongRating> GetByIdAsync(int id);
    }
}
