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
    public class UserFriendRepository : Repository<UserFriend>, IUserFriendRepository
    {
        public UserFriendRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserFriend> GetUserFriendByIdsWithFriendDataAsync(string userId, string friendId)
        {
            return await _dbContext.UserFriend.Include(prp => prp.Friend)
                                              .Include(prp => prp.User)
                                              .FirstOrDefaultAsync(prp => string.Equals(prp.FriendId, friendId) && string.Equals(prp.UserId, userId)
                                                                       || string.Equals(prp.FriendId, userId) && string.Equals(prp.UserId, friendId));
        }
    }
}
