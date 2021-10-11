using MusicWeb.Models.Entities.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Posts
{
    public interface IPostService
    {
        Task AddAsync(Post entity);
        Task UpdateAsync(Post entity);
        Task DeleteAsync(int id);
        Task<Post> GetByIdAsync(int id);
        Task<List<Post>> GetAllAsync();
    }
}
