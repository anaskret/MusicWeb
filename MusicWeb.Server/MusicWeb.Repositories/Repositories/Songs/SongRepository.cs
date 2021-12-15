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

        public async Task<List<TopSongsWithRating>> GetTopSongsWithRatingsAsync(int artistId)
        {
            var sql = @$"
SELECT TOP 3 T0.*, CAST(COALESCE(T3.AvgRating, 0) as numeric) as Rating
FROM Song T0
INNER JOIN Album T1 ON T1.Id = T0.AlbumId
INNER JOIN Artist T2 ON T2.Id = T1.ArtistId
LEFT JOIN
(
	SELECT SongId, AVG(Rating) as AvgRating
	FROM SongRating
	GROUP BY SongId
) T3 ON T3.SongId = T0.Id
WHERE T2.Id = {artistId}
ORDER BY COALESCE(T3.AvgRating, 0) DESC, T0.Name";

            var query = _dbContext.TopSongsWithRating.FromSqlRaw(sql);

            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
