using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Users
{
    public class UserFavoriteSongRepository : Repository<UserFavoriteSong>, IUserFavoriteSongRepository
    {
        public UserFavoriteSongRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserFavoriteSong>> GetAllWithSongAsync()
        {
            return await _dbContext.UserFavoriteSongs.Include(prp => prp.Song).ToListAsync();
        }
    }
}
