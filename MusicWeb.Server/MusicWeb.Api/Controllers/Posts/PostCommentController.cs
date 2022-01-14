using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
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
    public class PostCommentController : Controller
    {
        private readonly IPostCommentService _postCommentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PostCommentController(IPostCommentService postCommentService, 
                                     IMapper mapper, 
                                     ILogger logger)
        {
            _postCommentService = postCommentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(ApiRoutes.PostComments.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostCommentDto dto)
        {
            try
            {
                var entity = _mapper.Map<PostComment>(dto);
                await _postCommentService.AddAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(ApiRoutes.PostComments.GetAllByPostId)]
        public async Task<IActionResult> GetAllByPostId([FromRoute] int postId)
        {
            try
            {
                var entites = await _postCommentService.GetCommentsByPostIdAsync(postId);
                var models = _mapper.Map<List<GetPostCommentDto>>(entites);
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(ApiRoutes.PostComments.Update)]
        public async Task<IActionResult> Create([FromBody] PostCommentDto dto)
        {
            try
            {
                var entity = _mapper.Map<PostComment>(dto);
                await _postCommentService.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.PostComments.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int postId)
        {
            try
            {
                await _postCommentService.DeleteAsync(postId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return BadRequest(ex.Message);
            }
        }
    }
}
