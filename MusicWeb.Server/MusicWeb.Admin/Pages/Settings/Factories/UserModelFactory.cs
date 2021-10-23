using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MusicWeb.Admin.Models;
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
        private readonly IConfiguration _configuration;

        public UserModelFactory(IMapper mapper,
            IUserService userService,
            UserManager<ApplicationUser> userManager, 
            IConfiguration configuration)
        {
            _mapper = mapper;
            _userService = userService;
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<EditUserModel> PrepareEditAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            return _mapper.Map<EditUserModel>(user);
        }

        public async Task PrepareListAsync(List<UserListModel> list, PagerModel pager)
        {
            if (pager.PageIndex > 0)
                pager.PageIndex = pager.PageIndex - 1;

            var pageSize = _configuration.GetValue<int>("Settings:PageSize");
            var pagedList = await _userService.GetAllPagedAsync(pager.SearchString, pager.UserType, pager.PageIndex, pageSize);
            list.AddRange(_mapper.Map<List<UserListModel>>(pagedList.ToList()));

            pager.PageSize = pagedList.PageSize;
            pager.TotalRecords = pagedList.TotalCount;
            pager.PageIndex = pagedList.PageIndex;
            pager.UrlAdress = "/users/list";
        }
    }
}
