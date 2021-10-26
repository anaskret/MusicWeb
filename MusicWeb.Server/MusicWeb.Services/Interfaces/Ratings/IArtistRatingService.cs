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
        Task<List<ArtistRating>> GetAllByArtistIdAsync(int id);
        Task<ArtistRating> GetByIdAsync(int id);
    }
}
