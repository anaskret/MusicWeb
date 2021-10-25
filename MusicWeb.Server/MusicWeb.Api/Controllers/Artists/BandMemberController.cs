using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Artists
{
    [ApiController]
    [Authorize]
    public class BandMemberController : Controller
    {
        private readonly IBandService _bandService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public BandMemberController(IBandService bandService, IMapper mapper, ILogger<BandMemberController> logger)
        {
            _bandService = bandService;
            _mapper = mapper;
            _logger = logger;
        }

        /*[HttpPost(ApiRoutes.BandMembers.Create)]
        public async Task<IActionResult> CreateBandMember([FromBody] BandMemberDto dto)
        {
            try
            {
                var entity = _mapper.Map<BandMember>(dto);
                await _bandService.AddAsync(entity);

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
