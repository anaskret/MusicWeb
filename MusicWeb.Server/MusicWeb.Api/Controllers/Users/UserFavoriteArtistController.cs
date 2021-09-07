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
    public class UserFavoriteArtistController:Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteArtistService _userFavoriteArtistService;

        public UserFavoriteArtistController(ILogger<UserFavoriteArtistController> logger, IUserFavoriteArtistService userFavoriteArtistService)
        {
            _logger = logger;
            _userFavoriteArtistService = userFavoriteArtistService;
        }

        [HttpGet(ApiRoutes.UserFavoriteArtists.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = await _userFavoriteArtistService.GetAllAsync();
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFavoriteArtists.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userFavoriteArtistService.CreateAsync(model);
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
