using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
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

        public async Task<Album> GetFullAlbumDataByIdAsync(int id)
        {
            var entity = await _dbContext.Album
                .Include(songs => songs.Songs)
                .Include(reviews => reviews.AlbumReviews).FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }
    }
}
