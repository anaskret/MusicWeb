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

        public async Task<List<UserAndArtistPost>> GetPostForUserAsync(string userId, DateTime pageInitializeDate, int page = 0, int pageSize = int.MaxValue)
        {
			if (pageInitializeDate == DateTime.MinValue)
				pageInitializeDate = DateTime.Now;

            var sql = @$"
SELECT 
	T01.*, 
	cast(CASE 
		WHEN T02.Id IS NULL THEN 0
		ELSE 1
	END as bit) as IsLiked,
	COALESCE(T03.TotalLikes, 0) as TotalLikes
FROM(
	SELECT T0.Id, Text, CreateDate, PosterId, T2.UserName, null as Artist, null as ArtistId, null as Album, null as AlbumId, T2.ImagePath as Image, null as AlbumImage
	FROM Post T0
	LEFT JOIN UserFriend T1 ON T1.FriendId = T0.PosterId
	LEFT JOIN AspNetUsers T2 ON T2.Id = T0.PosterId
	WHERE T1.UserId = '{userId}'
	UNION
	SELECT T0.Id, Text, CreateDate, null as PosterId, null as UserName, T2.Name as Artist, T2.Id as ArtistId, T3.Name as Album, T3.Id as AlbumId, T2.ImagePath as Image, T3.ImagePath as AlbumImage
	FROM Post T0
	LEFT JOIN UserObservedArtist T1 ON T1.ArtistId = T0.ArtistPosterId
	LEFT JOIN Artist T2 ON T2.Id = T1.ArtistId
	LEFT JOIN Album T3 ON T3.Id = T0.AlbumId
	WHERE T1.UserId = '{userId}'
	) T01
LEFT JOIN PostLike T02 ON T02.PostId = T01.Id
LEFT JOIN
(
	SELECT COUNT(T031.PostId) as TotalLikes, T031.PostId
	FROM PostLike T031
	GROUP BY T031.PostId
) T03 ON T03.PostId = T01.Id
WHERE T01.CreateDate < '{pageInitializeDate}'
ORDER BY T01.CreateDate DESC
OFFSET {page} * {pageSize} ROWS
FETCH NEXT {pageSize} ROWS ONLY";

            var query = _dbContext.UserAndArtistPost.FromSqlRaw(sql);

            var entities = await query.ToListAsync();
            return entities;
        }
    }
}
