using MusicWeb.Models.Models.Identity;
using MusicWeb.Repositories.Interfaces.Identity;
using MusicWeb.Services.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<LoginResponse> LoginUser(LoginModel model)
        {
            return await _identityRepository.Login(model);
        }

        public async Task<RegisterResponse> RegisterUser(RegisterModel model)
        {
            var response = await _identityRepository.Register(model);

            return response;
        }
    }
}
