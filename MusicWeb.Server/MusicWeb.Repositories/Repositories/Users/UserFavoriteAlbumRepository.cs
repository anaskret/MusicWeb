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
    public class UserFavoriteAlbumRepository : Repository<UserFavoriteAlbum>, IUserFavoriteAlbumRepository
    {
        public UserFavoriteAlbumRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserFavoriteAlbum>> GetAllWithAlbumAsync()
        {
            return await _dbContext.UserFavoriteAlbum.Include(prp => prp.Album).ToListAsync();
        }
    }
}
