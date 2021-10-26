using Microsoft.EntityFrameworkCore;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Dtos.Posts;
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

        public async Task<List<GetPostDto>> GetPostForUserAsync(string userId)
        {
            var postsFromUsers = await (from T10 in _dbContext.Post
                                        join T11 in _dbContext.UserFriend on T10.PosterId equals T11.FriendId
                                        join T12 in _dbContext.Users on T10.PosterId equals T12.Id
                                        where string.Equals(T11.UserId, userId)
                                        select new GetPostDto()
                                        {
                                            Id = T10.Id,
                                            //AlbumId = T10.AlbumId,
                                            //AlbumName = "",
                                            //ArtistName = "",
                                            PosterName = T12.UserName,
                                            //ArtistPosterId = T10.ArtistPosterId,
                                            PosterId = T10.PosterId,
                                            CreateDate = T10.CreateDate,
                                            Text = T10.Text
                                        }).ToListAsync();
            /*var postsFromArtists = await (from T20 in _dbContext.Post
                                          join T21 in _dbContext.UserObservedArtist on T20.ArtistPosterId.GetValueOrDefault() equals T21.ArtistId
                                          join T22 in _dbContext.Album on T20.AlbumId.GetValueOrDefault() equals T22.Id
                                          join T23 in _dbContext.Artist on T20.ArtistPosterId.GetValueOrDefault() equals T23.Id
                                          where string.Equals(T21.UserId, userId)
                                          select new GetPostDto()
                                           {
                                               Id = T20.Id,
                                               AlbumId = T20.AlbumId,
                                               AlbumName = T22.Name,
                                               ArtistName = T23.Name,
                                               PosterName = "",
                                               ArtistPosterId = T20.ArtistPosterId,
                                               PosterId = T20.PosterId,
                                               CreateDate = T20.CreateDate,
                                               Text = T20.Text
                                          }).ToListAsync();

            postsFromUsers.AddRange(postsFromArtists);*/
            return postsFromUsers;
        }
    }
}
