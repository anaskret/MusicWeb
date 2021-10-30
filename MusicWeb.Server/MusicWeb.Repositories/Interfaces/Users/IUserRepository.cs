using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<List<ApplicationUser>> GetAllAsync();
        Task<IPagedList<ApplicationUser>> GetAllPagedAsync(Func<IQueryable<ApplicationUser>, IQueryable<ApplicationUser>> func = null,
            int pageIndex = 0, int pageSize = int.MaxValue, bool getOnlyTotalCount = false);
    }
}
