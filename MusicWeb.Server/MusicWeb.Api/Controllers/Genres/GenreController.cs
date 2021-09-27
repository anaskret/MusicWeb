using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Genres
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GenreController(IGenreService genreService, IMapper mapper, ILogger<GenreController> logger)
        {
            _genreService = genreService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet(ApiRoutes.Genres.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = _mapper.Map<List<GenreDto>>(await _genreService.GetAllAsync());
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Genres.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = _mapper.Map<GenreDto>(await _genreService.GetByIdAsync(id));
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Genres.Create)]
        public async Task<IActionResult> CreateGenre([FromBody] GenreDto dto)
        {
            try
            {
                var entity = _mapper.Map<Genre>(dto);
                await _genreService.AddAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Genres.Update)]
        public async Task<IActionResult> UpdateGenre([FromBody] GenreDto dto)
        {
            try
            {
                var entity = _mapper.Map<Genre>(dto);
                await _genreService.UpdateAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.Genres.Delete)]
        public async Task<IActionResult> DeleteGenre([FromRoute] int id)
        {
            try
            {
                await _genreService.DeleteAsync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
