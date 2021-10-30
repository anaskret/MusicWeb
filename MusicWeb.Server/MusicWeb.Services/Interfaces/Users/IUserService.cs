using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
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
        Task<IList<ApplicationUser>> GetAllAsync();
        Task<IPagedList<ApplicationUser>> GetAllPagedAsync(string searchString, UserType userType, int pageIndex = 0, int pageSize = int.MaxValue);
        Task DeleteAsync(string id);
    }
}
