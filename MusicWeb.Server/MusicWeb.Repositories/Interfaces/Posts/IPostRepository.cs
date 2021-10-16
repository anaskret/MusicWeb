using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Posts
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<List<GetPostDto>> GetPostForUserAsync(string userId);
    }
}
