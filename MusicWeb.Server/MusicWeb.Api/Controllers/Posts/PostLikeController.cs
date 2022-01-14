using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
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
    public class PostLikeController : Controller
    {
        private readonly IPostLikeService _postLikeService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PostLikeController(IMapper mapper, 
                                  ILogger<PostLikeController> logger, 
                                  IPostLikeService postLikeService)
        {
            _mapper = mapper;
            _logger = logger;
            _postLikeService = postLikeService;
        }

        [HttpPost(ApiRoutes.PostLikes.Create)]
        public async Task<IActionResult> Create([FromRoute] string userId, [FromRoute] int postId)
        {
            try
            {
                await _postLikeService.AddAsync(new PostLike { UserId = userId, PostId = postId });
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.PostLikes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string userId, [FromRoute] int postId)
        {
            try
            {
                await _postLikeService.DeleteAsync(new PostLike { UserId = userId, PostId = postId });
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
