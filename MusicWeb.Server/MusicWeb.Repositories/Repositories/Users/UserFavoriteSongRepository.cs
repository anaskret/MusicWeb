using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Users
{
    public class UserFavoriteSongRepository : Repository<UserFavoriteSong>, IUserFavoriteSongRepository
    {
        public UserFavoriteSongRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserFavoriteSong>> GetAllWithSongByUserIdAsync(string userId)
        {
            return await _dbContext.UserFavoriteSong.Include(prp => prp.Song).Where(prp => prp.UserId == userId).ToListAsync();
        }

        public async Task<List<SongRatingAverage>> GetFavoriteSongData(string userId)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Reviews, 0) as ReviewsCount
            FROM Song T0
            LEFT JOIN(SELECT SongId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM SongRating GROUP BY SongId) T1 ON T1.SongId = T0.Id
            LEFT JOIN (SELECT SongId, COUNT(SongId) as Favorite FROM UserFavoriteSong GROUP BY SongId) T2 ON T0.Id = T2.SongId
            LEFT JOIN (SELECT SongId, COUNT(SongId) as Reviews FROM SongReview GROUP BY SongId) T3 ON T0.Id = T3.SongId
            RIGHT JOIN UserFavoriteSong T4 ON T0.Id = T4.SongId AND T4.UserId = '{userId}'";

            var query = _dbContext.SongRatingAverage.FromSqlRaw(sql);
            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
