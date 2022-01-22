using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Identity
{
    public interface IIdentityService
    {
        Task<LoginResponse> LoginUser(LoginModel model);
        Task<RegisterResponse> RegisterUser(RegisterModel model);
        Task ResetPasswordAsync(string userName);
        Task<string> GenerateNewTokenAsync(ApplicationUser user);
    }
}
