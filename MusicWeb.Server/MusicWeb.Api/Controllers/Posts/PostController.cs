using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Services.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Posts
{
    [ApiController]
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PostController(IPostService postService, IMapper mapper, ILogger logger)
        {
            _postService = postService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// WIP
        /// </summary>
        [HttpGet(ApiRoutes.Posts.GetUserPosts)]
        public async Task<IActionResult> GetUserPosts([FromRoute] string userId, [FromRoute] int page, [FromRoute] int pageSize)
        {
            try
            {
                var entities = await _postService.GetUserPostsAsync(userId, page, pageSize);
                var models = _mapper.Map<List<GetPostDto>>(entities);

                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets all posts
        /// </summary>
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public async Task<IActionResult> GetAllPosts()
        {
            try
            {
                var models = _mapper.Map<List<PostDto>>(await _postService.GetAllAsync());
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a single post
        /// </summary>
        [HttpGet(ApiRoutes.Posts.GetById)]
        public async Task<IActionResult> GetPostById([FromRoute] int id)
        {
            try
            {
                var model = _mapper.Map<PostDto>(await _postService.GetByIdAsync(id));
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates a post
        /// </summary>
        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
        {
            try
            {
                var entity = _mapper.Map<Post>(dto);
                await _postService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a post
        /// </summary>
        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> UpdatePost([FromBody] PostDto dto)
        {
            try
            {
                var entity = _mapper.Map<Post>(dto);
                await _postService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a post
        /// </summary>
        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            try
            {
                await _postService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
