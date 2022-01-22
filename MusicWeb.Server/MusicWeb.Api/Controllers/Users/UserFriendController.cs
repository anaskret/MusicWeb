using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    [ApiController]
    [Authorize]
    public class UserFriendController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFriendService _userFriendService;
        private readonly IMapper _mapper;
        public UserFriendController(ILogger<UserFavoriteSongController> logger, IUserFriendService userFriendService, IMapper mapper)
        {
            _logger = logger;
            _userFriendService = userFriendService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserFriends.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] string userId)
        {
            try
            {
                var models = _mapper.Map<List<UserFriendDto>>(await _userFriendService.GetAllByUserIdAsync(userId));
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFriends.Create)]
        public async Task<IActionResult> Create([FromBody] CreateUserFriendDto model)
        {
            try
            {
                var entity = _mapper.Map<UserFriend>(model);
                await _userFriendService.CreateNewRequestAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Accepts Friend Request.
        /// </summary>
        /// <remarks>
        /// UserId = User accepting the request &#xA;
        /// FriendId = User sending the request
        /// </remarks>
        [HttpPost(ApiRoutes.UserFriends.AcceptRequest)]
        public async Task<IActionResult> AcceptRequest([FromBody] CreateUserFriendDto model)
        {
            try
            {
                var entity = _mapper.Map<UserFriend>(model);
                await _userFriendService.AcceptFriendRequestAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFriends.Delete)]
        public async Task<IActionResult> Delete([FromRoute] string userId, string friendId)
        {
            try
            {
                await _userFriendService.DeleteAsync(userId, friendId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.UserFriends.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string userId, string friendId)
        {
            try
            {
                var model = _mapper.Map<UserFriendDto>(await _userFriendService.GetSingleByUserIdAndFriendIdAsync(userId, friendId));
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
