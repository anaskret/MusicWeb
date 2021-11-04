using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Songs
{
    public class SongReviewController : Controller
    {
        private readonly ISongReviewService _songReviewService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SongReviewController(ISongReviewService songReviewService, IMapper mapper, ILogger<SongReviewController> logger)
        {
            _songReviewService = songReviewService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.SongReviews.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _songReviewService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.SongReviews.GetAll)]
        public async Task<IActionResult> GetSongReviews()
        {
            try
            {
                var response = await _songReviewService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.SongReviews.Create)]
        public async Task<IActionResult> CreateSongReview([FromBody] SongReviewDto dto)
        {
            try
            {
                var entity = _mapper.Map<SongReview>(dto);
                await _songReviewService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.SongReviews.Update)]
        public async Task<IActionResult> UpdateSongReview([FromBody] SongReviewDto dto)
        {
            try
            {
                var entity = _mapper.Map<SongReview>(dto);
                await _songReviewService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.SongReviews.Delete)]
        public async Task<IActionResult> DeleteSongReview([FromRoute] int id)
        {
            try
            {
                await _songReviewService.DeleteAsync(id);

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
