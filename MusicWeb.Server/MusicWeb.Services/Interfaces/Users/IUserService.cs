using MusicWeb.Models.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserService
    {
        Task<UserDto> GetUserProfileById(string id);
        Task<List<UserDto>> GetAllAsync();
    }
}
