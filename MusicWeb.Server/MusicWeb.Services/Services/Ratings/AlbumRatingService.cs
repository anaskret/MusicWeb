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
    public class AlbumRatingService : IAlbumRatingService
    {
        private readonly IAlbumRatingRepository _albumRatingRepository;

        public AlbumRatingService(IAlbumRatingRepository albumRatingRepository)
        {
            _albumRatingRepository = albumRatingRepository;
        }

        public async Task AddAsync(AlbumRating entity)
        {
            await _albumRatingRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _albumRatingRepository.DeleteAsync(entity);
        }

        public async Task DeleteRangeByUserIdAsync(string userId)
        {
            var entities = await GetAllByUserIdAsync(userId);
            await _albumRatingRepository.DeleteRangeAsync(entities.ToList());
        }
        public async Task<IList<AlbumRating>> GetAllByAlbumIdAsync(int id)
        {
            return await _albumRatingRepository.GetAllAsync(entity => entity.Where(prp => prp.AlbumId == id));
        }

        public async Task<IList<AlbumRating>> GetAllByUserIdAsync(string id)
        {
            return await _albumRatingRepository.GetAllAsync(entity => entity.Where(prp => string.Equals(prp.UserId, id)));
        }

        public async Task<AlbumRating> GetByIdAsync(int id)
        {
            return await _albumRatingRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(AlbumRating entity)
        {
            await _albumRatingRepository.UpdateAsync(entity);
        }

        public async Task<AlbumRating> GetUserRating(int id, string userId)
        {
            var entity = await _albumRatingRepository.GetSingleAsync(prp => string.Equals(prp.UserId, userId) && string.Equals(prp.AlbumId, id));
            return entity;
        }
    }
}
