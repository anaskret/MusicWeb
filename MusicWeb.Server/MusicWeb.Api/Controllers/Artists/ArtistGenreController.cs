using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Artists
{
    public class ArtistGenreController : Controller
    {
        private readonly IArtistGenreService _artistGenreService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ArtistGenreController(IArtistGenreService artistGenreService, IMapper mapper, ILogger<ArtistGenreController> logger)
        {
            _artistGenreService = artistGenreService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(ApiRoutes.ArtistGenres.Create)]
        public async Task<IActionResult> CreateArtistGenre([FromBody] ArtistGenreDto dto)
        {
            try
            {
                var entity = _mapper.Map<ArtistGenre>(dto);
                await _artistGenreService.AddAsync(entity);

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
