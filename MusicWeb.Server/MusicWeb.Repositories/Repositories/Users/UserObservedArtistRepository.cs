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
    public class UserObservedArtistRepository : Repository<UserObservedArtist>, IUserObservedArtistRepository
    {
        public UserObservedArtistRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserObservedArtist>> GetAllWithArtistByUserIdAsync(string userId)
        {
            return await _dbContext.UserObservedArtist.Include(prp => prp.Artist).Where(prp => string.Equals(prp.UserId, userId)).ToListAsync();
        }

        public async Task<List<ArtistRatingAverage>> GetFavoriteArtistData(string userId, int pageNum = 0, int pageSize = 15)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount,0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount,
            COALESCE(T3.Observed, 0) as ObservedCount
            FROM Artist T0
            LEFT JOIN(SELECT ArtistId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM ArtistRating GROUP BY ArtistId) T1 ON T1.ArtistId = T0.Id
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Favorite FROM UserFavoriteArtist GROUP BY ArtistId) T2 ON T0.Id = T2.ArtistId
            LEFT JOIN (SELECT ArtistId, COUNT(ArtistId) as Observed FROM UserObservedArtist GROUP BY ArtistId) T3 ON T0.Id = T3.ArtistId
            RIGHT JOIN UserObservedArtist T4 ON T0.Id = T4.ArtistId AND T4.userId = '{userId}'";

            var query = _dbContext.ArtistRatingAverage.FromSqlRaw(sql);
            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
