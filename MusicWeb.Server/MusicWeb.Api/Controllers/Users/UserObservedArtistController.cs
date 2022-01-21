using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    [ApiController]
    [Authorize]
    public class UserObservedArtistController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserObservedArtistService _userObservedArtistService;
        private readonly IMapper _mapper;

        public UserObservedArtistController(ILogger logger, 
                                            IUserObservedArtistService userObservedArtistService, 
                                            IMapper mapper)
        {
            _logger = logger;
            _userObservedArtistService = userObservedArtistService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserObservedArtists.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] string userId)
        {
            try
            {
                var models = _mapper.Map<List<UserFavoriteDto>>(await _userObservedArtistService.GetAllByUserIdAsync(userId));
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserObservedArtists.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userObservedArtistService.CreateAsync(_mapper.Map<UserObservedArtist>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserObservedArtists.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userObservedArtistService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.UserObservedArtists.GetUserArtist)]
        public async Task<IActionResult> GetUserArtist([FromRoute] string userId, [FromRoute] int artistId)
        {
            try
            {
                var models = _mapper.Map<List<UserObservedArtist>>(await _userObservedArtistService.GetAllByUserIdAsync(userId));
                var model = models.Find(prp => prp.ArtistId == artistId);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet(ApiRoutes.UserObservedArtists.GetFavoriteData)]
        public async Task<IActionResult> GetArtistsData(string userId)
        {
            try
            {
                var response = _mapper.Map<List<ArtistRatingAverage>>(await _userObservedArtistService.GetFavoriteArtistDataAsync(userId));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
