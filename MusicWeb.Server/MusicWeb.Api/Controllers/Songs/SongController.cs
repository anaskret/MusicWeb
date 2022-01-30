using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Songs
{
    [ApiController]
    [Authorize]
    public class SongController : Controller
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SongController(ISongService songService, IMapper mapper, ILogger<SongController> logger)
        {
            _songService = songService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Songs.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _songService.GetByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetAllSongsForArtist)]
        public async Task<IActionResult> GetAllForArtist(int artistId)
        {
            try
            {
                var response = _mapper.Map<List<SongDto>>(await _songService.GetAllForArtist(artistId));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetTopSongs)]
        public async Task<IActionResult> GetArtistTopSongs([FromRoute] int artistId)
        {
            try
            {
                var response = await _songService.GetTopSongsWithRatingAsync(artistId);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet(ApiRoutes.Songs.GetAll)]
        public async Task<IActionResult> GetFullSongsData()
        {
            try
            {
                var response = _mapper.Map<List<SongDto>>(await _songService.GetAllAsync());
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetFullData)]
        public async Task<IActionResult> GetSongsFullDataByIdAsync([FromRoute] int id)
        {
            try
            {
                var response = await _songService.GetSongFullDataByIdAsync(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Songs.Create)]
        public async Task<IActionResult> CreateSong([FromBody] SongDto dto)
        {
            try
            {
                var entity = _mapper.Map<Song>(dto);
                await _songService.AddAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Songs.Update)]
        public async Task<IActionResult> UpdateSong([FromBody] SongDto dto)
        {
            try
            {
                var entity = _mapper.Map<Song>(dto);
                await _songService.UpdateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.Songs.Delete)]
        public async Task<IActionResult> DeleteSong([FromRoute] int id)
        {
            try
            {
                await _songService.DeleteAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetSongRatingAverage)]
        public async Task<IActionResult> GetSongRatingAverage([FromRoute] int id)
        {
            try
            {
                var response = await _songService.GetSongRatingAverage(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetAllPagedSearchString)]
        public async Task<IActionResult> GetAllPagedSearchString([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd, [FromRoute] string searchString = "")
        {
            try
            {
                var response = _mapper.Map<List<SongRatingAverage>>(await _songService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize, searchString));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Songs.GetAllPaged)]
        public async Task<IActionResult> GetAllPaged([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd)
        {
            try
            {
                var response = _mapper.Map<List<SongRatingAverage>>(await _songService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize));
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Songs.UpdateImage)]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateArtistImage([FromBody] List<SongFileUpdateDto> dto)
        {
            try
            {
                await _songService.UpdateImageAsync(dto);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet(ApiRoutes.Songs.GetRankingPaged)]
        public async Task<IActionResult> GetRankingPaged([FromRoute] RankSortType sortType, [FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                var response = await _songService.GetPagedRankingAsync(sortType, pageNum, pageSize);
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
