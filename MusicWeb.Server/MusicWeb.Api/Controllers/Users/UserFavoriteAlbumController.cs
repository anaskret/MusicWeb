using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Users
{
    [ApiController]
    public class UserFavoriteAlbumController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteAlbumService _userFavoriteAlbumService;
        private readonly IMapper _mapper;

        public UserFavoriteAlbumController(ILogger<UserFavoriteAlbumController> logger,
            IUserFavoriteAlbumService userFavoriteAlbumService,
            IMapper mapper)
        {
            _logger = logger;
            _userFavoriteAlbumService = userFavoriteAlbumService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserFavoriteAlbums.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] string userId)
        {
            try
            {
                var models = _mapper.Map<List<UserFavoriteDto>>(await _userFavoriteAlbumService.GetAllByUserIdAsync(userId));
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFavoriteAlbums.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userFavoriteAlbumService.CreateAsync(_mapper.Map<UserFavoriteAlbum>(model));
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFavoriteAlbums.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFavoriteAlbumService.DeleteAsync(id);
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
