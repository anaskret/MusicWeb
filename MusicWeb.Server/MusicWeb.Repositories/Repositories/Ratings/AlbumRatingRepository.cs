using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Repositories.Interfaces.Ratings;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Ratings
{
    public class AlbumRatingRepository : Repository<AlbumRating>, IAlbumRatingRepository
    {
        public AlbumRatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }


        public async Task<IList<AlbumRating>> GetUserRating(int id, string userId)
        {
                var entities = await _dbContext.AlbumRating
                    .Include(album => album.Album)
                    .Include(user => user.User)
                    .ToListAsync();
                return entities;
            
        }
    }
}
