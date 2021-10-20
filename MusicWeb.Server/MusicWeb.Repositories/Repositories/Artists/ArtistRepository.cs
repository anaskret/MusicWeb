using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Artists
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Artist> GetFullArtistDataByIdAsync(int id)
        {
            var entity = await _dbContext.Artist
                                             .Include(origin => origin.City)
                                             .ThenInclude(origin => origin.State)
                                             .ThenInclude(origin => origin.Country)
                                             .Include(albums => albums.Albums)
                                             .ThenInclude(genres => genres.AlbumGenre)
                                             .Include(band => band.Band)
                                             .ThenInclude(member => member.Member)
                                             .Include(comments => comments.ArtistComments).FirstOrDefaultAsync(prp => prp.Id == id);

            return entity;
        }

        public async Task GetArtistsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
           /* SELECT *, T1.Rating
FROM Artist T0
JOIN(SELECT ArtistId, AVG(Rating) as Rating FROM ArtistRating GROUP BY ArtistId) T1 ON T1.ArtistId = T0.Id
WHERE T0.Name LIKE(CASE
                        WHEN LEN('test') > 0 THEN '%test%'

                        ELSE '%%'

                    END)
	OR(T0.EstablishmentDate < '12.15.2015 00:00:00' AND T0.EstablishmentDate < '12.15.2021 00:00:00')
ORDER BY

         CASE 0 WHEN 0 THEN T0.Name ELSE '' END ASC,
         CASE 1 WHEN 0 THEN T0.Name ELSE '' END DESC,
         CASE 2 WHEN 0 THEN T1.Rating ELSE '' END ASC,
         CASE 3 WHEN 0 THEN T1.Rating ELSE '' END DESC
OFFSET 0 * 15 ROWS
  FETCH NEXT 15 ROWS ONLY;*/
        }
    }
}
