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
    public class ArtistCommentsController : Controller
    {
        private readonly IArtistCommentService _artistCommentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ArtistCommentsController(IArtistCommentService artistCommentService, IMapper mapper, ILogger<ArtistCommentsController> logger)
        {
            _artistCommentService = artistCommentService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost(ApiRoutes.ArtistComments.Create)]
        public async Task<IActionResult> CreateComment([FromBody] ArtistCommentDto dto)
        {
            try
            {
                var entity = _mapper.Map<ArtistComment>(dto);
                await _artistCommentService.AddAsync(entity);

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
