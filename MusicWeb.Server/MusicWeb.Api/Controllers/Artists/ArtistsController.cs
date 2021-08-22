using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Artists
{
    public class ArtistsController : Controller
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ArtistsController(IArtistService artistService, ILogger<ArtistsController> logger, IMapper mapper)
        {
            _artistService = artistService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Artists.GetFullData)]
        public async Task<IActionResult> GetFullArtistData([FromRoute] int id)
        {
            try
            {
                var response = await _artistService.GetFullArtistInfoByIdAsync(id);
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Artists.Create)]
        public async Task<IActionResult> CreateArtist([FromBody] ArtistDto dto)
        {
            try
            {
                var entity = _mapper.Map<Artist>(dto);
                await _artistService.AddAsync(entity);

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
