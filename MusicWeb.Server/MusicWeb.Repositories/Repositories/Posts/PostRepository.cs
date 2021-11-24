using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Repositories.Interfaces.Posts;
using MusicWeb.Repositories.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Posts
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<UserAndArtistPost>> GetPostForUserAsync(string userId, int page = 0, int pageSize = int.MaxValue)
        {
            var sql = @$"SELECT T01.* FROM(
SELECT T0.Id, Text, CreateDate, PosterId, T2.UserName, null as Artist, null as ArtistId, null as Album, null as AlbumId
FROM Post T0
LEFT JOIN UserFriend T1 ON T1.FriendId = T0.PosterId
LEFT JOIN AspNetUsers T2 ON T2.Id = T0.PosterId
WHERE T1.UserId = '{userId}') T01
ORDER BY T01.CreateDate DESC
OFFSET {page} * {pageSize} ROWS
FETCH NEXT {pageSize} ROWS ONLY";

            var query = _dbContext.UserAndArtistPost.FromSqlRaw(sql);

            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
