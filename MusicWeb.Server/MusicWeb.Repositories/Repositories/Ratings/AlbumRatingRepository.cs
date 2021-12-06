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
    }
}
