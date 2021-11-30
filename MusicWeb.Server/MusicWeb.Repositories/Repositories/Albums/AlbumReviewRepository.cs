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
    public class AlbumReviewRepository : Repository<AlbumReview>, IAlbumReviewRepository
    {
        public AlbumReviewRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<AlbumReview> GetAlbumReviewFullDataByIdAsync(int id)
        {
            var entity = await _dbContext.AlbumReview
                 .Include(user => user.User)
                 .Include(album => album.Album)
                 .ThenInclude(artist => artist.Artist)
                 .FirstOrDefaultAsync(prp => prp.Id == id);
            return entity;
        }

    }
}
