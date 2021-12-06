using MusicWeb.Models.Entities.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Ratings
{
    public interface IAlbumRatingService
    {
        Task AddAsync(AlbumRating entity);
        Task UpdateAsync(AlbumRating entity);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
        Task<IList<AlbumRating>> GetAllByAlbumIdAsync(int id);
        Task<IList<AlbumRating>> GetAllByUserIdAsync(string id);
        Task<AlbumRating> GetByIdAsync(int id);
    }
}
