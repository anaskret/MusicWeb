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

        public class AlbumRatingController : Controller
        {
            private readonly IMapper _mapper;
            private readonly ILogger _logger;
            private readonly IAlbumRatingService _albumRatingService;

            public AlbumRatingController(IMapper mapper, ILogger<AlbumRatingController> logger, IAlbumRatingService albumRatingService)
            {
                _mapper = mapper;
                _logger = logger;
                _albumRatingService = albumRatingService;
            }

            /// <summary>
            /// Gets a single rating
            /// </summary>
            [HttpGet(ApiRoutes.AlbumRatings.GetById)]
            public async Task<IActionResult> GetById([FromRoute] int id)
            {
                try
                {
                    var response = _mapper.Map<AlbumRatingDto>(await _albumRatingService.GetByIdAsync(id));
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            /// <summary>
            /// Gets all ratings for an album
            /// </summary>
            [HttpGet(ApiRoutes.AlbumRatings.GetAll)]
            public async Task<IActionResult> GetAllForAlbum([FromRoute] int id)
            {
                try
                {
                    var response = _mapper.Map<List<AlbumRatingDto>>(await _albumRatingService.GetAllByAlbumIdAsync(id));
                    return Ok(response);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            /// <summary>
            /// Creates an album rating
            /// </summary>
            [HttpPost(ApiRoutes.AlbumRatings.Create)]
            public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumRatingDto dto)
            {
                try
                {
                    var entity = _mapper.Map<AlbumRating>(dto);
                    await _albumRatingService.AddAsync(entity);

                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }

            /// <summary>
            /// Updates a rating for an album
            /// </summary>
            [HttpPut(ApiRoutes.AlbumRatings.Update)]
            public async Task<IActionResult> UpdateAlbum([FromBody] AlbumRatingDto dto)
            {
                try
                {
                    var entity = _mapper.Map<AlbumRating>(dto);
                    await _albumRatingService.UpdateAsync(entity);

                    return Ok();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                    return StatusCode(500, ex.Message);
                }
            }
        
        [HttpGet(ApiRoutes.AlbumRatings.GetUserRating)]
        public async Task<IActionResult> GetUserRating([FromRoute] int id, string userId)
        {
            try
            {
                var response = _mapper.Map<AlbumRatingDto>(await _albumRatingService.GetUserRating(id, userId));
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
