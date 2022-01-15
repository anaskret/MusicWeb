using Microsoft.AspNetCore.Mvc;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Models.Identity;
using MusicWeb.Services.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Identity
{
    [ApiController]
    public class IdentityController:Controller
    {
        private readonly IIdentityService _identityService;

        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                var response = await _identityService.LoginUser(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); ;
            }

        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var response = await _identityService.RegisterUser(model);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Identity.PasswordReset)]
        public async Task<IActionResult> PasswordReset([FromBody] PasswordChangeDto dto)
        {
            try
            {
                await _identityService.ResetPasswordAsync(dto.UserName);
                return Ok();
            }
            catch(ArgumentException)
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
