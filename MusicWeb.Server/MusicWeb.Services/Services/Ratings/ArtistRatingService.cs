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

        public async Task<List<ArtistRating>> GetAllByArtistIdAsync(int id)
        {
            return await _artistRatingRepository.GetAll().Where(prp => prp.ArtistId == id).ToListAsync();
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
