using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicWeb.Admin.Pages.Settings.Factories.Interfaces;
using MusicWeb.Admin.Pages.Settings.Models;
using MusicWeb.Models.Identity;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Settings.Factories
{
    public class UserModelFactory : IUserModelFactory
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserModelFactory(IMapper mapper,
            IUserService userService,
            UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
        }

        public async Task<EditUserModel> PrepareEditAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<EditUserModel>(user);
        }

        public async Task PrepareListAsync(List<UserListModel> list)
        {
            list.AddRange(_mapper.Map<List<UserListModel>>(await _userService.GetAllAsync()));
        }
    }
}
