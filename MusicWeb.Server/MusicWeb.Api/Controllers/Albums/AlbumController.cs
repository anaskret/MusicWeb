using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Albums.Create;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Albums
{
    [ApiController]
    [Authorize]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AlbumController(IAlbumService albumService, IMapper mapper, ILogger<AlbumController> logger)
        {
            _albumService = albumService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Albums.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _albumService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Albums.GetAlbumRatingAverage)]
        public async Task<IActionResult> GetAlbumRatingAverage([FromRoute] int id)
        {
            try
            {
                var response = await _albumService.GetAlbumRatingAverage(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet(ApiRoutes.Albums.GetAll)]
        public async Task<IActionResult> GetFullAlbumData()
        {
            try
            {
                var response = _mapper.Map<List<AlbumDto>>(await _albumService.GetAllAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet(ApiRoutes.Albums.GetAllForArtist)]
        public async Task<IActionResult> GetAllForArtist(int artistId)
        {
            try
            {
                var response = _mapper.Map<List<AlbumDto>>(await _albumService.GetAllForArtist(artistId));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Albums.GetFullData)]
        public async Task<IActionResult> GetFullAlbumDataByIdAsync([FromRoute] int id)
        {
            try
            {
                var response = await _albumService.GetFullAlbumDataByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Albums.Create)]
        public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumDto dto)
        {
            try
            {
                var entity = _mapper.Map<Album>(dto);
                await _albumService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Albums.Update)]
        public async Task<IActionResult> UpdateAlbum([FromBody] AlbumDto dto)
        {
            try
            {
                var entity = _mapper.Map<Album>(dto);
                await _albumService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.Albums.Delete)]
        public async Task<IActionResult> DeleteAlbum([FromRoute] int id)
        {
            try
            {
                await _albumService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Albums.GetAllPagedSearchString)]
        public async Task<IActionResult> GetAllPagedSearchString([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd, [FromRoute] string searchString = "")
        {
            try
            {
                var response = _mapper.Map<List<AlbumRatingAverage>>(await _albumService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize, searchString));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Albums.GetAllPaged)]
        public async Task<IActionResult> GetAllPaged([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd)
        {
            try
            {
                var response = await _albumService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Albums.UpdateImage)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtistImage([FromBody] AlbumFileUpdateDto dto)
        {
            try
            {
                var path = await _albumService.UpdateImageAsync(dto);

                return Ok(path);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet(ApiRoutes.Albums.GetRankingPaged)]
        public async Task<IActionResult> GetRankingPaged([FromRoute] RankSortType sortType, [FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                var response = await _albumService.GetPagedRankingAsync(sortType, pageNum, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Albums.GetSongs)]
        public async Task<IActionResult> GetSongs([FromRoute] int albumId, [FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                var response = await _albumService.GetAlbumSongsAsync(albumId, pageNum, pageSize);
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
