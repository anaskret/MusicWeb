using AutoMapper;
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
    public class ArtistRatingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IArtistRatingService _artistRatingService;

        public ArtistRatingController(IMapper mapper, ILogger<ArtistRatingController> logger, IArtistRatingService artistRatingService)
        {
            _mapper = mapper;
            _logger = logger;
            _artistRatingService = artistRatingService;
        }

        /// <summary>
        /// Gets a single rating
        /// </summary>
        [HttpGet(ApiRoutes.ArtistRatings.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = _mapper.Map<ArtistRatingDto>(await _artistRatingService.GetByIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets all ratings for an artist
        /// </summary>
        [HttpGet(ApiRoutes.ArtistRatings.GetAll)]
        public async Task<IActionResult> GetAllForArtist([FromRoute] int id)
        {
            try
            {
                var response = _mapper.Map<List<ArtistRatingDto>>(await _artistRatingService.GetAllByArtistIdAsync(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates an artist rating
        /// </summary>
        [HttpPost(ApiRoutes.ArtistRatings.Create)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistRatingDto dto)
        {
            try
            {
                var entity = _mapper.Map<ArtistRating>(dto);
                await _artistRatingService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a rating for an artist
        /// </summary>
        [HttpPut(ApiRoutes.ArtistRatings.Update)]
        public async Task<IActionResult> UpdateArtist([FromBody] ArtistRatingDto dto)
        {
            try
            {
                var entity = _mapper.Map<ArtistRating>(dto);
                await _artistRatingService.UpdateAsync(entity);

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
