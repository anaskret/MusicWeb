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
    public class SongRatingService : ISongRatingService
    {
        private readonly ISongRatingRepository _songRatingRepository;

        public SongRatingService(ISongRatingRepository songRatingRepository)
        {
            _songRatingRepository = songRatingRepository;
        }

        public async Task AddAsync(SongRating entity)
        {
            await _songRatingRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _songRatingRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _songRatingRepository.DeleteRangeAsync(entities.ToList());
        }
        public async Task<IList<SongRating>> GetAllBySongIdAsync(int id)
        {
            return await _songRatingRepository.GetAllAsync(entity => entity.Where(prp => prp.SongId == id));
        }

        public async Task<IList<SongRating>> GetAllByUserIdAsync(string id)
        {
            return await _songRatingRepository.GetAllAsync(entity => entity.Where(prp => string.Equals(prp.UserId, id)));
        }

        public async Task<SongRating> GetByIdAsync(int id)
        {
            return await _songRatingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(SongRating entity)
        {
            await _songRatingRepository.UpdateAsync(entity);
        }
    }
}
