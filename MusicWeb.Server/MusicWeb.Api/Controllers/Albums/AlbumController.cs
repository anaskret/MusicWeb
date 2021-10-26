using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Albums.Create;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Albums
{
    [ApiController]
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

        [HttpPost(ApiRoutes.Albums.Create)]
        public async Task<IActionResult> CreateAlbum([FromBody] CreateAlbumDto dto)
        {
            try
            {
                var entity = _mapper.Map<Album>(dto);
                await _albumService.AddAsync(entity);

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
