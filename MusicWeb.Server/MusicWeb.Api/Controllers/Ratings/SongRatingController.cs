using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Ratings;
using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Services.Interfaces.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Ratings
{
    [ApiController]
    [Authorize]

    public class SongRatingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly ISongRatingService _songRatingService;

        public SongRatingController(IMapper mapper, ILogger<SongRatingController> logger, ISongRatingService songRatingService)
        {
            _mapper = mapper;
            _logger = logger;
            _songRatingService = songRatingService;
        }

        /// <summary>
        /// Gets a single rating
        /// </summary>
        [HttpGet(ApiRoutes.SongRatings.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = _mapper.Map<SongRatingDto>(await _songRatingService.GetByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets all ratings for an song
        /// </summary>
        [HttpGet(ApiRoutes.SongRatings.GetAll)]
        public async Task<IActionResult> GetAllForSong([FromRoute] int id)
        {
            try
            {
                var response = _mapper.Map<List<SongRatingDto>>(await _songRatingService.GetAllBySongIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates an song rating
        /// </summary>
        [HttpPost(ApiRoutes.SongRatings.Create)]
        public async Task<IActionResult> CreateSong([FromBody] CreateSongRatingDto dto)
        {
            try
            {
                var entity = _mapper.Map<SongRating>(dto);
                await _songRatingService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a rating for an song
        /// </summary>
        [HttpPut(ApiRoutes.SongRatings.Update)]
        public async Task<IActionResult> UpdateSong([FromBody] SongRatingDto dto)
        {
            try
            {
                var entity = _mapper.Map<SongRating>(dto);
                await _songRatingService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.SongRatings.GetUserRating)]
        public async Task<IActionResult> GetUserRating([FromRoute] int id, string userId)
        {
            try
            {
                var response = _mapper.Map<SongRatingDto>(await _songRatingService.GetUserRating(id, userId));
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
