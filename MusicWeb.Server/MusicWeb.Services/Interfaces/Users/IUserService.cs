using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<ApplicationUser> GetUserProfileById(string id);
        Task<List<ApplicationUser>> GetAllAsync();
    }
}
