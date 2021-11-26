using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Repositories.Interfaces.Posts;
using MusicWeb.Services.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task AddAsync(Post entity)
        {
            await _postRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _postRepository.DeleteAsync(entity);
        }

        public async Task<IList<Post>> GetAllAsync()
        {
            return await _postRepository.GetAllAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _postRepository.GetByIdAsync(id);
        }

        public async Task<List<UserAndArtistPost>> GetUserPostsAsync(string userId, int page, int pageSize)
        {
            return await _postRepository.GetPostForUserAsync(userId, page, pageSize);
        }

        public async Task UpdateAsync(Post entity)
        {
            await _postRepository.UpdateAsync(entity);
        }
    }
}
