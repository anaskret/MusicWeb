using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [ApiController]
    [Authorize]
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

        /// <summary>
        /// Gets all countries
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetAllCountries)]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = _mapper.Map<List<CountryDto>>(await _originService.GetAllCountriesAsync());
                return Ok(countries);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a single country
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetCountryById)]
        public async Task<IActionResult> GetCountryById([FromRoute] int id)
        {
            try
            {
                var country = _mapper.Map<CountryDto>(await _originService.GetCountryByIdAsync(id));
                return Ok(country);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates a country
        /// </summary>
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

        /// <summary>
        /// Updates a country
        /// </summary>
        [HttpPut(ApiRoutes.Origins.UpdateCountry)]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryDto dto)
        {
            try
            {
                var entity = _mapper.Map<Country>(dto);
                await _originService.UpdateCountryAsync(entity);

                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a country with all its states and citites
        /// </summary>
        [HttpDelete(ApiRoutes.Origins.DeleteCountry)]
        public async Task<IActionResult> DeleteCountry([FromRoute] int id)
        {
            try
            {
                await _originService.DeleteCountryAsync(id);
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
