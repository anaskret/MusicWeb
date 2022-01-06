using MusicWeb.Models.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Identity
{
    public interface IIdentityRepository
    {
        Task<LoginResponse> Login(LoginModel model);
        Task<RegisterResponse> Register(RegisterModel model);
        Task<string> ResetPasswordAsync(string userName, string newPassword);
    }
}
