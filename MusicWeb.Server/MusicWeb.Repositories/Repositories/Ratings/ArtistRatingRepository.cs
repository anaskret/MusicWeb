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
    public class ArtistRatingRepository : Repository<ArtistRating>, IArtistRatingRepository
    {
        public ArtistRatingRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<IList<ArtistRating>> GetUserRating(int id, string userId)
        {
            var entities = await _dbContext.ArtistRating
                .Include(artist => artist.Artist)
                .Include(user => user.User)
                .ToListAsync();
            return entities;

        }
    }
}
