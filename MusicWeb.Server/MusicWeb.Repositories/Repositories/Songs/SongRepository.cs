using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Songs
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<SongRatingAverage> GetSongAverageRating(int id)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            T1.RatingsCount
            FROM Song T0
            LEFT JOIN(SELECT SongId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM SongRating GROUP BY SongId) T1 ON T1.SongId = T0.Id";
            var query = _dbContext.SongRatingAverage.FromSqlRaw(sql);
            var entity = await query.FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<Song> GetSongFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.Song
                .Include(album => album.Album)
                .Include(composer => composer.Composer)
                .Include(songReviews => songReviews.SongReviews)
                .ThenInclude(user => user.User)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }
    }
}
