using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Songs
{
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


        [HttpGet(ApiRoutes.Songs.GetAll)]
        public async Task<IActionResult> GetFullSongsData()
        {
            try
            {
                var response = await _songService.GetAllAsync();
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


    }
}
