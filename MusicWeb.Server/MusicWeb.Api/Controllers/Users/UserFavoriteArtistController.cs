using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    [Authorize]
    public class UserFavoriteArtistController :Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteArtistService _userFavoriteArtistService;
        private readonly IMapper _mapper;

        public UserFavoriteArtistController(ILogger<UserFavoriteArtistController> logger, IUserFavoriteArtistService userFavoriteArtistService, IMapper mapper)
        {
            _logger = logger;
            _userFavoriteArtistService = userFavoriteArtistService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserFavoriteArtists.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] string userId)
        {
            try
            {
                var models = _mapper.Map<List<UserFavoriteDto>>(await _userFavoriteArtistService.GetAllByUserIdAsync(userId));
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
                await _userFavoriteArtistService.CreateAsync(_mapper.Map<UserFavoriteArtist>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFavoriteArtists.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFavoriteArtistService.DeleteAsync(id);
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
