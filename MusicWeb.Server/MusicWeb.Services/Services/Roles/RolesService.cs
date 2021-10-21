using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Identity;
using MusicWeb.Services.Interfaces.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Roles
{
    public class RolesService : IRolesService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task RemoveAdminRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, "Admin");

            await _userManager.UpdateAsync(user);
        }

        public async Task RemoveArtistRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.RemoveFromRoleAsync(user, "Artist");

            await _userManager.UpdateAsync(user);
        }

        public async Task SetAdminRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Admin");

            await _userManager.UpdateAsync(user);
        }

        public async Task SetArtistRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Artist");

            await _userManager.UpdateAsync(user);
        }
    }
}
