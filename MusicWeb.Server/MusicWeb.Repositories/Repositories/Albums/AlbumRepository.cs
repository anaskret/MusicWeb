using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Albums
{
    public class AlbumRepository : Repository<Album>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<AlbumRatingAverage> GetAlbumAverageRating(int id)
        {
            var sql = $@"SELECT T0.*, ROUND(Coalesce(T1.Rating, 0), 2) as Rating, 
            T1.RatingsCount
            FROM Album T0
            LEFT JOIN(SELECT AlbumId, AVG(Cast(Rating as float)) as Rating, COUNT(Rating) as RatingsCount FROM AlbumRating GROUP BY AlbumId) T1 ON T1.AlbumId = T0.Id";
            var query = _dbContext.AlbumRatingAverage.FromSqlRaw(sql);
            var entity = await query.FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

        public async Task<Album> GetFullAlbumDataByIdAsync(int id)
        {
            var entity = await _dbContext.Album
                .Include(songs => songs.Songs)
                .Include(reviews => reviews.AlbumReviews)
                .ThenInclude(user => user.User)
                .Include(artist => artist.Artist)
                .Include(genre => genre.AlbumGenre)
                .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }
       
    }
}
