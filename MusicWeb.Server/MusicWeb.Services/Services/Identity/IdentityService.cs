using Microsoft.AspNetCore.Identity.UI.Services;
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
        private readonly IEmailSender _emailSender;

        public IdentityService(IIdentityRepository identityRepository, 
                               IEmailSender emailSender)
        {
            _identityRepository = identityRepository;
            _emailSender = emailSender;
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

        public async Task ResetPasswordAsync(string userName)
        {
            var generator = new PasswordGeneratorService();
            var newPassword = generator.Generate();

            var email = await _identityRepository.ResetPasswordAsync(userName, newPassword);

            await _emailSender.SendEmailAsync(email, "New password", $"Your new password: {newPassword}");
        }
    }
}
