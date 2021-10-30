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
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
            var role = await _roleManager.RoleExistsAsync("Admin");
            if (!role)
                await _roleManager.CreateAsync(new IdentityRole("Admin"));

            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Admin");

            await _userManager.UpdateAsync(user);
        }

        public async Task SetArtistRoles(string userId)
        {
            var role = await _roleManager.RoleExistsAsync("Artist");
            if (!role)
                await _roleManager.CreateAsync(new IdentityRole("Artist"));

            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.AddToRoleAsync(user, "Artist");

            await _userManager.UpdateAsync(user);
        }
    }
}
