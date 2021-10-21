using AutoMapper;
using MusicWeb.Admin.Pages.Settings.Models;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Extenstions.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserListModel>();
            CreateMap<ApplicationUser, UserModel>();
            CreateMap<ApplicationUser, EditUserModel>();
            CreateMap<EditUserModel, ApplicationUser>();
        }
    }
}
