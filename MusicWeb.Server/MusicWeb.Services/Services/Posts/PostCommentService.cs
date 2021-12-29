using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Interfaces.Posts;
using MusicWeb.Services.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Posts
{
    public class PostCommentService : IPostCommentService
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostCommentService(IPostCommentRepository postCommentRepository, 
                                  IPostService postService, 
                                  UserManager<ApplicationUser> userManager)
        {
            _postCommentRepository = postCommentRepository;
            _postService = postService;
            _userManager = userManager;
        }

        public async Task AddAsync(PostComment entity)
        {
            await CheckCommentEntity(entity);

            entity.PostDate = DateTime.Now;
            await _postCommentRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentException("Comment doesn't exist");

            await _postCommentRepository.DeleteAsync(entity);
        }

        public async Task<List<PostComment>> GetCommentsByPostIdAsync(int postId)
        {
            var entites = await _postCommentRepository.GetAllAsync(obj => obj.Where(prp => prp.PostId == postId).Include(prp => prp.User));
            return entites.ToList();
        }

        public async Task<PostComment> GetByIdAsync(int id)
        {
            return await _postCommentRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(PostComment entity)
        {
            await CheckCommentEntity(entity);

            await _postCommentRepository.UpdateAsync(entity);
        }

        private async Task CheckCommentEntity(PostComment entity)
        {
            var user = await _userManager.FindByIdAsync(entity.UserId);
            var post = await _postService.GetByIdAsync(entity.PostId);
            if (user == null)
                throw new ArgumentException("User with that ID doesn't exist");
            if (post == null)
                throw new ArgumentException("Post with that ID doesn't exist");
        }
    }
}
