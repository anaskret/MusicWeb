using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces.Albums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Albums
{
    public class AlbumReviewController : Controller
    {
        private readonly IAlbumReviewService _albumReviewService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AlbumReviewController(IAlbumReviewService albumReviewService, IMapper mapper, ILogger<AlbumReviewController> logger)
        {
            _albumReviewService = albumReviewService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.AlbumReviews.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _albumReviewService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet(ApiRoutes.AlbumReviews.GetAll)]
        public async Task<IActionResult> GetFullAlbumReviewsData()
        {
            try
            {
                var response = await _albumReviewService.GetAllAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.AlbumReviews.Create)]
        public async Task<IActionResult> CreateAlbumReview([FromBody] AlbumReviewDto dto)
        {
            try
            {
                var entity = _mapper.Map<AlbumReview>(dto);
                await _albumReviewService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.AlbumReviews.Update)]
        public async Task<IActionResult> UpdateAlbumReview([FromBody] AlbumReviewDto dto)
        {
            try
            {
                var entity = _mapper.Map<AlbumReview>(dto);
                await _albumReviewService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.AlbumReviews.Delete)]
        public async Task<IActionResult> DeleteAlbumReview([FromRoute] int id)
        {
            try
            {
                await _albumReviewService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.AlbumReviews.GetFullData)]
        public async Task<IActionResult> GetAlbumReviewsFullDataByIdAsync([FromRoute] int id)
        {
            try
            {
                var response = await _albumReviewService.GetAlbumReviewFullDataByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

       
        [HttpGet(ApiRoutes.AlbumReviews.GetAllPagedSearchString)]
        public async Task<IActionResult> GetAllPagedSearchString([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd, [FromRoute] string searchString = "")
        {
            try
            {
                var response = await _albumReviewService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize, searchString);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet(ApiRoutes.AlbumReviews.GetAllPaged)]
        public async Task<IActionResult> GetAllPaged([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd)
        {
            try
            {
                var response = _mapper.Map<List<AlbumReview>>(await _albumReviewService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize));
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
