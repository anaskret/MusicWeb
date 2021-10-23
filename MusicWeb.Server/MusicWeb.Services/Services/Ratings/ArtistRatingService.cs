using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Repositories.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Ratings
{
    public class ArtistRatingService : IArtistRatingService
    {
        private readonly IArtistRatingRepository _artistRatingRepository;

        public ArtistRatingService(IArtistRatingRepository artistRatingRepository)
        {
            _artistRatingRepository = artistRatingRepository;
        }

        public async Task AddAsync(ArtistRating entity)
        {
            await _artistRatingRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _artistRatingRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _artistRatingRepository.DeleteRangeAsync(entities.ToList());
        }
        public async Task<IList<ArtistRating>> GetAllByArtistIdAsync(int id)
        {
            return await _artistRatingRepository.GetAllAsync(entity => entity.Where(prp => prp.ArtistId == id));
        }

        public async Task<IList<ArtistRating>> GetAllByUserIdAsync(string id)
        {
            return await _artistRatingRepository.GetAllAsync(entity => entity.Where(prp => string.Equals(prp.UserId, id)));
        }

        public async Task<ArtistRating> GetByIdAsync(int id)
        {
            return await _artistRatingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(ArtistRating entity)
        {
            await _artistRatingRepository.UpdateAsync(entity);
        }
    }
}
