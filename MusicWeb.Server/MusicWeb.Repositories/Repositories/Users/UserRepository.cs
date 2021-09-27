using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetUserByIdAsync(string id)
        {
            var user = await _dbContext.Users.Include(prp => prp.UserFavoriteArtists)
                                             .ThenInclude(prp => prp.Artist)
                                             .Include(prp => prp.UserFavoriteAlbums)
                                             .ThenInclude(prp => prp.Album)
                                             .Include(prp => prp.UserFavoriteSongs)
                                             .ThenInclude(prp => prp.Song)
                                             .Include(prp => prp.UserFriends)
                                             .ThenInclude(prp => prp.Friend)
                                             .FirstOrDefaultAsync(prp => prp.Id == id);

            return user;
        }

        public async Task<List<ApplicationUser>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }
    }
}
