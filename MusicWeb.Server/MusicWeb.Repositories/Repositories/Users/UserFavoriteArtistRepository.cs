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
    public class UserFavoriteArtistRepository : Repository<UserFavoriteArtist>, IUserFavoriteArtistRepository
    {
        public UserFavoriteArtistRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
