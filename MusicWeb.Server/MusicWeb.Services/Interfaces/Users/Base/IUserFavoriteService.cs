using MusicWeb.Models.Dtos.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users.Base
{
    public interface IUserFavoriteService
    {
        Task<List<UserFavoriteDto>> GetAllAsync();
        Task CreateAsync(UserFavoriteDto model);
        Task DeleteAsync(int id);
    }
}
