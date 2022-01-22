using Microsoft.AspNetCore.Identity;
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
    public class PostLikeService : IPostLikeService
    {
        private readonly IPostLikeRepository _postLikeRepository;
        private readonly IPostService _postService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostLikeService(IPostLikeRepository postLikeRepository, 
                               IPostService postService, 
                               UserManager<ApplicationUser> userManager)
        {
            _postLikeRepository = postLikeRepository;
            _postService = postService;
            _userManager = userManager;
        }
        public async Task AddAsync(PostLike entity)
        {
            var post = await _postService.GetByIdAsync(entity.PostId);
            var user = await _userManager.FindByIdAsync(entity.UserId);
            if (post == null)
                throw new Exception("Post doesn't exists");
            if (user == null)
                throw new Exception("User doesn't exists");

            await _postLikeRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(PostLike entity)
        {
            var postLikeEntity = await _postLikeRepository.GetSingleAsync(prp => prp.PostId == entity.PostId && string.Equals(prp.UserId, entity.UserId));
            if (postLikeEntity == null)
                throw new Exception("PostLike doesn't exist");

            await _postLikeRepository.DeleteAsync(postLikeEntity);
        }
    }
}
