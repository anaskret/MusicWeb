using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Identity;
using MusicWeb.Repositories.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Repositories.Identity
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public IdentityRepository(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !isPasswordCorrect)
            {
                throw new ArgumentException("Wrong username/password");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            var response = new LoginResponse()
            {
                UserId = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                UserName = user.UserName
            };

            return response;
        }

        public async Task<RegisterResponse> Register(RegisterModel model) 
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            var userByEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                throw new ArgumentException("User already exists!");
            if(userByEmail != null)
                throw new ArgumentException("Email already taken!");


            ApplicationUser user = new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BirthDate = model.BirthDate,
                Type = UserType.Standard,
                ArtistId = 0
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                throw new ArgumentException("User creation failed! Please check user details and try again.");
            }

            var response = new RegisterResponse()
            {
                Status = "Success",
                Message = "User created successfully!"
            };

            return response;
        }
    }
}
