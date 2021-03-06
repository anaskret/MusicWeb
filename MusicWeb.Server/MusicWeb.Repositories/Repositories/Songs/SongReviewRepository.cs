using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Songs
{
    public class SongReviewRepository : Repository<SongReview>, ISongReviewRepository
    {
        public SongReviewRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
