using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Artists.Create;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Artists
{
    [ApiController]
    [Authorize]
    public class ArtistCommentController : Controller
    {
        private readonly IArtistCommentService _artistCommentService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public ArtistCommentController(IArtistCommentService artistCommentService, IMapper mapper, ILogger<ArtistCommentController> logger)
        {
            _artistCommentService = artistCommentService;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Gets all comments for an artist
        /// </summary>
        [HttpGet(ApiRoutes.ArtistComments.GetAllById)]
        public async Task<IActionResult> GetArtists([FromRoute] int id)
        {
            try
            {
                var entities = _mapper.Map<List<ArtistCommentDto>>(await _artistCommentService.GetAllByArtistIdAsync(id));

                return Ok(entities);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a single comment
        /// </summary>
        [HttpGet(ApiRoutes.ArtistComments.GetById)]
        public async Task<IActionResult> GetArtist([FromRoute] int id)
        {
            try
            {
                var entity = _mapper.Map<ArtistCommentDto>(await _artistCommentService.GetByIdAsync(id));

                return Ok(entity);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates a comment
        /// </summary>
        [HttpPost(ApiRoutes.ArtistComments.Create)]
        public async Task<IActionResult> CreateComment([FromBody] BaseArtistCommentDto dto)
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

        /// <summary>
        /// Updates a comment
        /// </summary>
        [HttpPut(ApiRoutes.ArtistComments.Update)]
        public async Task<IActionResult> UpdateComment([FromBody] ArtistCommentDto dto)
        {
            try
            {
                var entity = _mapper.Map<ArtistComment>(dto);
                await _artistCommentService.UpdateAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a comment
        /// </summary>
        [HttpDelete(ApiRoutes.ArtistComments.Delete)]
        public async Task<IActionResult> UpdateComment([FromRoute] int id)
        {
            try
            {
                await _artistCommentService.DeleteAsync(id);

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
