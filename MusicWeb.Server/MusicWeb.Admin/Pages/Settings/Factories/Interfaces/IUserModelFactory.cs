﻿using MusicWeb.Admin.Models;
using MusicWeb.Admin.Pages.Settings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Settings.Factories.Interfaces
{
    public interface IUserModelFactory
    {
        Task PrepareListAsync(List<UserListModel> list, PagerModel pager);
        Task<EditUserModel> PrepareEditAsync(string userId);
    }
}