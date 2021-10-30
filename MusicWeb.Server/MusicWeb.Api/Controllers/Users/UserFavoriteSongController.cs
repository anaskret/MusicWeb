﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserFavoriteSongController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFavoriteSongService _userFavoriteSongService;
        private readonly IMapper _mapper;

        public UserFavoriteSongController(ILogger<UserFavoriteSongController> logger, 
            IUserFavoriteSongService userFavoriteSongService, 
            IMapper mapper)
        {
            _logger = logger;
            _userFavoriteSongService = userFavoriteSongService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserFavoriteSongs.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] string userId)
        {
            try
            {
                var models = _mapper.Map<List<UserFavoriteDto>>(await _userFavoriteSongService.GetAllByUserIdAsync(userId));
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFavoriteSongs.Create)]
        public async Task<IActionResult> Create([FromBody] UserFavoriteDto model)
        {
            try
            {
                await _userFavoriteSongService.CreateAsync(_mapper.Map<UserFavoriteSong>(model));
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFavoriteSongs.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFavoriteSongService.DeleteAsync(id);
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
