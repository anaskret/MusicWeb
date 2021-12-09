using MusicWeb.Models.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Posts
{
    public interface IPostLikeService
    {
        Task AddAsync(PostLike entity);
        Task DeleteAsync(PostLike entity);
    }
}
