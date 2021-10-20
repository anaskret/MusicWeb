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
    [ApiController]
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
        /// Gets all states in a country
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetCountryStates)]
        public async Task<IActionResult> GetCountryStates([FromRoute] int id)
        {
            try
            {
                var states = _mapper.Map<List<StateDto>>(await _originService.GetStatesByCountryAsync(id));
                return Ok(states);
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

        /// <summary>
        /// Gets all states
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetAllStates)]
        public async Task<IActionResult> GetAllStates()
        {
            try
            {
                var states = _mapper.Map<List<StateDto>>(await _originService.GetAllStatesAsync());
                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a single state
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetStateById)]
        public async Task<IActionResult> GetStateById([FromRoute] int id)
        {
            try
            {
                var state = _mapper.Map<StateDto>(await _originService.GetStateByIdAsync(id));
                return Ok(state);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets all cities in a state
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetStateCities)]
        public async Task<IActionResult> GetStateCities([FromRoute] int id)
        {
            try
            {
                var cities = _mapper.Map<List<CityDto>>(await _originService.GetCitiesByStateAsync(id));
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Create a state
        /// </summary>
        [HttpPost(ApiRoutes.Origins.CreateState)]
        public async Task<IActionResult> CreateState([FromBody] StateDto dto)
        {
            try
            {
                var entity = _mapper.Map<State>(dto);
                await _originService.AddStateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a state
        /// </summary>
        [HttpPut(ApiRoutes.Origins.UpdateState)]
        public async Task<IActionResult> UpdateState([FromBody] StateDto dto)
        {
            try
            {
                var entity = _mapper.Map<State>(dto);
                await _originService.UpdateStateAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a state with all its cities
        /// </summary>
        [HttpDelete(ApiRoutes.Origins.DeleteState)]
        public async Task<IActionResult> DeleteState([FromRoute] int id)
        {
            try
            {
                await _originService.DeleteStateAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets all cities
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetAllCities)]
        public async Task<IActionResult> GetAllCities()
        {
            try
            {
                var cities = _mapper.Map<List<CityDto>>(await _originService.GetAllCitiesAsync());
                return Ok(cities);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Gets a single city
        /// </summary>
        [HttpGet(ApiRoutes.Origins.GetCityById)]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            try
            {
                var city = _mapper.Map<CityDto>(await _originService.GetCityByIdAsync(id));
                return Ok(city);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Creates a city
        /// </summary>
        [HttpPost(ApiRoutes.Origins.CreateCity)]
        public async Task<IActionResult> CreateCity([FromBody] CityDto dto)
        {
            try
            {
                var entity = _mapper.Map<City>(dto);
                await _originService.AddCityAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Updates a city
        /// </summary>
        [HttpPut(ApiRoutes.Origins.UpdateCity)]
        public async Task<IActionResult> UpdateCity([FromBody] CityDto dto)
        {
            try
            {
                var entity = _mapper.Map<City>(dto);
                await _originService.UpdateCityAsync(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a city
        /// </summary>
        [HttpDelete(ApiRoutes.Origins.DeleteCity)]
        public async Task<IActionResult> DeleteCity([FromRoute] int id)
        {
            try
            {
                await _originService.DeleteCityAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
