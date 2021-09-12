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
    public class UserFavoriteAlbumController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteAlbumService _userFavoriteAlbumService;

        public UserFavoriteAlbumController(ILogger<UserFavoriteAlbumController> logger, IUserFavoriteAlbumService userFavoriteAlbumService)
        {
            _logger = logger;
            _userFavoriteAlbumService = userFavoriteAlbumService;
        }

        [HttpGet(ApiRoutes.UserFavoriteAlbums.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userFavoriteAlbumService.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFavoriteAlbums.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userFavoriteAlbumService.CreateAsync(model);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFavoriteAlbums.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFavoriteAlbumService.DeleteAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
