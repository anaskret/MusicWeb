using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;

        public SongReviewController(ISongReviewService songReviewService, IMapper mapper, ILogger<SongReviewController> logger, UserManager<ApplicationUser> userManager)
        {
            _songReviewService = songReviewService;
            _mapper = mapper;
            _logger = logger;
            _userManager = userManager;
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
        [HttpGet(ApiRoutes.SongReviews.GetFullData)]
        public async Task<IActionResult> GetSongReviewsFullDataByIdAsync([FromRoute] int id)
        {
            try
            {
                var response = await _songReviewService.GetSongReviewFullDataByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.SongReviews.GetSongReviews)]
        public async Task<IActionResult> GetAlbumReviewsPagedAsync([FromRoute] int songId, [FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                var response = await _songReviewService.GetSongReviewsPagedAsync(songId, pageNum, pageSize);
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
                var user = await _userManager.FindByIdAsync(entity.UserId);
                var userName = user.UserName;
                entity.User = new ApplicationUser();
                entity.User.UserName = userName;
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


        [HttpGet(ApiRoutes.SongReviews.GetAllPagedWithRating)]
        public async Task<IActionResult> GetAllPagedWithRating([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd)
        {
            try
            {
                var response = await _songReviewService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize);
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
