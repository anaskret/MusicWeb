using MusicWeb.Models.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Posts
{
    public interface IPostCommentService
    {
        Task<List<PostComment>> GetCommentsByPostIdAsync(int postId);
        Task<PostComment> GetByIdAsync(int id);
        Task AddAsync(PostComment entity);
        Task UpdateAsync(PostComment entity);
        Task DeleteAsync(int id);
    }
}
