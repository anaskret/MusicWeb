using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Roles
{
    public interface IRolesService
    {
        Task SetAdminRoles(string userId);
        Task SetArtistRoles(string userId);
        Task RemoveAdminRoles(string userId);
        Task RemoveArtistRoles(string userId);
    }
}
