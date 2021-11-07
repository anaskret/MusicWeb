using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Identity;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    [ApiController]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, ILogger<UserController> logger, IMapper mapper)
        {
            _userService = userService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = _mapper.Map<List<UserDto>>(await _userService.GetAllAsync());
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
                var model = _mapper.Map<UserDto>(await _userService.GetUserProfileById(id));
                return Ok(model);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates user password
        /// </summary>
        [HttpPut(ApiRoutes.Users.UpdatePassword)]
        public async Task<IActionResult> UpdatePasswordAsync([FromBody] UpdatePasswordDto dto)
        {
            try
            {
                await _userService.UpdatePasswordAsync(dto);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates user first and last names
        /// </summary>
        [HttpPut(ApiRoutes.Users.UpdateNames)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateNameDto dto)
        {
            try
            {
                await _userService.UpdateNameAsync(dto);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates user email
        /// </summary>
        [HttpPut(ApiRoutes.Users.UpdateEmail)]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateEmailDto dto)
        {
            try
            {
                await _userService.UpdateEmailAsync(dto);

                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates user image
        /// </summary>
        [HttpPut(ApiRoutes.Users.UpdateImage)]
        public async Task<IActionResult> UpdateArtistImage([FromBody] UserImageDto dto)
        {
            try
            {
                await _userService.UpdateImageAsync(dto);

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
