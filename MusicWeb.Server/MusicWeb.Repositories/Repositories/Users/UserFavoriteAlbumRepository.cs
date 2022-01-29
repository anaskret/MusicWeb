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
    public class UserFavoriteAlbumRepository : Repository<UserFavoriteAlbum>, IUserFavoriteAlbumRepository
    {
        public UserFavoriteAlbumRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserFavoriteAlbum>> GetAllWithAlbumByUserIdAsync(string userId)
        {
            return await _dbContext.UserFavoriteAlbum.Include(prp => prp.Album).Where(prp => string.Equals(prp.UserId, userId)).ToListAsync();
        }
        public async Task<List<AlbumRatingAverage>> GetFavoriteAlbumData(string userId, int pageNum = 0, int pageSize = 15)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            COALESCE(T1.RatingsCount, 0) as RatingsCount, 
            COALESCE(T2.Favorite, 0) as FavoriteCount, 
            COALESCE(T3.Reviews, 0) as ReviewsCount,
            T5.Name as ArtistName
            FROM Album T0
            LEFT JOIN(SELECT AlbumId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM AlbumRating GROUP BY AlbumId) T1 ON T1.AlbumId = T0.Id
            LEFT JOIN(SELECT AlbumId, COUNT(AlbumId) as Favorite FROM UserFavoriteAlbum GROUP BY AlbumId) T2 ON T0.Id = T2.AlbumId
            LEFT JOIN(SELECT AlbumId, COUNT(AlbumId) as Reviews FROM AlbumReview GROUP BY AlbumId) T3 ON T0.Id = T3.AlbumId
            LEFT JOIN Artist T5
            ON T0.ArtistId = T5.Id
            RIGHT JOIN UserFavoriteAlbum T4 ON T0.Id = T4.AlbumId AND T4.UserId = '{userId}'
            WHERE T0.IsConfirmed = 1";

            var query = _dbContext.AlbumRatingAverage.FromSqlRaw(sql);
            var entities = await query.ToListAsync();
            return entities;
        }
        /*
                public async Task<List<UserFavoriteAlbum>> GetUserFavoriteAlbumByAlbumIdAsync(string userId, int albumId)
                {
                    return await _dbContext.UserFavoriteAlbum.Include(prp => prp.Album).Where(prp => string.Equals(prp.UserId, userId)).ToListAsync();
                }

            }
         */
    }
}
