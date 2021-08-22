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
    }
}
