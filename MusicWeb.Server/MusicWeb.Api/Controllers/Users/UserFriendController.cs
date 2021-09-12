using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    public class UserFriendController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFriendService _userFriendService;

        public UserFriendController(ILogger<UserFavoriteSongController> logger, IUserFriendService userFriendService)
        {
            _logger = logger;
            _userFriendService = userFriendService;
        }

        [HttpGet(ApiRoutes.UserFriends.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userFriendService.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFriends.Create)]
        public async Task<IActionResult> Create([FromBody] UserFriendDto model)
        {
            try
            {
                await _userFriendService.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFriends.Delete)]
        public async Task<IActionResult> Create([FromRoute] int id)
        {
            try
            {
                await _userFriendService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.UserFriends.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = await _userFriendService.GetByIdAsync(id);
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
