using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userService.GetAllAsync();
                return Ok(models);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Users.GetUserProfile)]
        public async Task<IActionResult> GetFullProfile([FromRoute] string id)
        {
            try
            {
                var model = await _userService.GetUserProfileById(id);
                return Ok(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
