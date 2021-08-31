using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Origins;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Services.Interfaces.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Origins
{
    public class OriginsController : Controller
    {
        private readonly IOriginService _originService;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public OriginsController(IOriginService originService, ILogger<OriginsController> logger, IMapper mapper)
        {
            _originService = originService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost(ApiRoutes.Origins.CreateCountry)]
        public async Task<IActionResult> CreateCountry([FromBody] CountryDto dto)
        {
            try
            {
                var entity = _mapper.Map<Country>(dto);
                await _originService.AddCountryAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Origins.CreateState)]
        public async Task<IActionResult> CreateCountry([FromBody] StateDto dto)
        {
            try
            {
                var entity = _mapper.Map<State>(dto);
                await _originService.AddStateAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost(ApiRoutes.Origins.CreateCity)]
        public async Task<IActionResult> CreateCity([FromBody] CityDto dto)
        {
            try
            {
                var entity = _mapper.Map<City>(dto);
                await _originService.AddCityAsync(entity);

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
