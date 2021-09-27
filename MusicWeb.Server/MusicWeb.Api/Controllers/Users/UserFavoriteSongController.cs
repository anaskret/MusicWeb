using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    public class UserFavoriteSongController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteSongService _userFavoriteSongService;

        public UserFavoriteSongController(ILogger<UserFavoriteSongController> logger, IUserFavoriteSongService userFavoriteSongService)
        {
            _logger = logger;
            _userFavoriteSongService = userFavoriteSongService;
        }

        [HttpGet(ApiRoutes.UserFavoriteSongs.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userFavoriteSongService.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFavoriteSongs.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userFavoriteSongService.CreateAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFavoriteSongs.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFavoriteSongService.DeleteAsync(id);
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
