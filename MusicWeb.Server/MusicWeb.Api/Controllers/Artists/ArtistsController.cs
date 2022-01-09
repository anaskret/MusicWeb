using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Artists.Create;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Artists
{
    [ApiController]
    [Authorize]
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

        /// <summary>
        /// Gets full data for an artist or a band
        /// </summary>
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

        /// <summary>
        /// Gets a single artist or a band without extra data
        /// </summary>
        [HttpGet(ApiRoutes.Artists.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = _mapper.Map<ArtistDto>(await _artistService.GetByIdAsync(id));
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets paged artists and bands woth search string
        /// </summary>
        /// <remarks>
        /// SortTypes: &#xA; 
        ///     0 - Alphabetical Ascending &#xA;
        ///     1 - Alphabetical Descending &#xA;
        ///     2 - Popularity Ascending &#xA; 
        ///     3 - Popularity Descending &#xA;
        /// </remarks>
        [HttpGet(ApiRoutes.Artists.GetAllPagedSearchString)]
        public async Task<IActionResult> GetAllPagedSearchStriny([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd, [FromRoute] string searchString = "")
        {
            try
            {
                var response = _mapper.Map<List<ArtistDto>>(await _artistService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize, searchString));
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets paged artists and bands
        /// </summary>
        /// <remarks>
        /// SortTypes: &#xA; 
        ///     0 - Alphabetical Ascending &#xA;
        ///     1 - Alphabetical Descending &#xA;
        ///     2 - Popularity Ascending &#xA; 
        ///     3 - Popularity Descending &#xA;
        /// </remarks>
        [HttpGet(ApiRoutes.Artists.GetAllPaged)]
        public async Task<IActionResult> GetAllPaged([FromRoute] int pageNum, [FromRoute] int pageSize, [FromRoute] SortType sortType, [FromRoute] DateTime createDateStart, [FromRoute] DateTime createDateEnd)
        {
            try
            {
                var response = _mapper.Map<List<ArtistRatingAverage>>(await _artistService.GetPagedAsync(sortType, createDateStart, createDateEnd, pageNum, pageSize));
                return Ok(response);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Artists.GetArtistRatingAverage)]
        public async Task<IActionResult> GetAlbumRatingAverage([FromRoute] int id)
        {
            try
            {
                var response = await _artistService.GetArtistRatingAverage(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet(ApiRoutes.Artists.GetRankingPaged)]
        public async Task<IActionResult> GetRankingPaged([FromRoute] RankSortType sortType, [FromRoute] int pageNum, [FromRoute] int pageSize)
        {
            try
            {
                var response = await _artistService.GetPagedRankingAsync(sortType, pageNum, pageSize);
                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        /*
                /// <summary>
                /// Creates an artist or a band.
                /// </summary>
                /// <remarks>
                /// To add a band member set Type to Band Member and BandId = SomeBandId &#xA;
                /// To add an artist image pass image bytes in ImageBytes, otherwise set the property to an empty string &#xA;
                /// </remarks>
                [HttpPost(ApiRoutes.Artists.Create)]
                public async Task<IActionResult> CreateArtist([FromBody] CreateArtistDto dto)
                {
                    try
                    {
                        var entity = _mapper.Map<Artist>(dto);
                        await _artistService.AddAsync(entity, dto.ImageBytes);

                        return Ok();
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        return StatusCode(500, ex.Message);
                    }
                }

                /// <summary>
                /// Updates an artist or a band
                /// </summary>
                [HttpPut(ApiRoutes.Artists.Update)]
                public async Task<IActionResult> UpdateArtist([FromBody] ArtistDto dto)
                {
                    try
                    {
                        var entity = _mapper.Map<Artist>(dto);
                        await _artistService.UpdateAsync(entity);

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        return StatusCode(500, ex.Message);
                    }
                }

                /// <summary>
                /// Updates artist image
                /// </summary>
                [HttpPut(ApiRoutes.Artists.UpdateImage)]
                public async Task<IActionResult> UpdateArtistImage([FromBody] ArtistFileUpdateDto dto)
                {
                    try
                    {
                        await _artistService.UpdateImageAsync(dto);

                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        return StatusCode(500, ex.Message);
                    }
                }

                /// <summary>
                /// Deletes an artist or a band
                /// </summary>
                [HttpDelete(ApiRoutes.Artists.Delete)]
                public async Task<IActionResult> DeleteArtist([FromRoute] int id)
                {
                    try
                    {
                        await _artistService.DeleteAsync(id);

                        return Ok();
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message);
                        return StatusCode(500, ex.Message);
                    }
                }*/
    }
}
