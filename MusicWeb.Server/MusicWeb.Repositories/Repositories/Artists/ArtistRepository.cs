using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
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

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _dbContext.Artists.ToListAsync();
        }

        public async Task<Artist> GetFullArtistDataByIdAsync(int id)
        {
            var entity = await _dbContext.Artists
                                           .Include(origin => origin.Country)
                                           .Include(origin => origin.State)
                                           .Include(origin => origin.City)
                                          .Include(genre => genre.ArtistGenres)
                                          .ThenInclude(genre => genre.Genre)
                                          .Include(albums => albums.Albums)
                                          .Include(band => band.Band)
                                          .ThenInclude(member => member.Member)
                                          .Include(comments => comments.ArtistComments).FirstOrDefaultAsync(prp => prp.Id == id);

            return entity;
        }
    }
}
