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
    public class UserFriendController : Controller
    {
        private readonly ILogger _logger;
        private readonly IUserFriendService _userFriendService;
        private readonly IMapper _mapper;
        public UserFriendController(ILogger<UserFavoriteSongController> logger, IUserFriendService userFriendService, IMapper mapper)
        {
            _logger = logger;
            _userFriendService = userFriendService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.UserFriends.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var models = _mapper.Map<List<UserFriendDto>>(await _userFriendService.GetAllAsync());
                return Ok(models);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.UserFriends.Create)]
        public async Task<IActionResult> Create([FromBody] UserFriendDto model)
        {
            try
            {
                var entity = _mapper.Map<UserFriend>(model);
                await _userFriendService.CreateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut(ApiRoutes.UserFriends.Update)]
        public async Task<IActionResult> Update([FromBody] UserFriendDto model)
        {
            try
            {
                var entity = _mapper.Map<UserFriend>(model);
                await _userFriendService.UpdateAsync(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete(ApiRoutes.UserFriends.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _userFriendService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(ApiRoutes.UserFriends.GetById)]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var model = _mapper.Map<UserFriendDto>(await _userFriendService.GetByIdAsync(id));
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
