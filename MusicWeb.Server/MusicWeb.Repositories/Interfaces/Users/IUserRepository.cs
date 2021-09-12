﻿using MusicWeb.Models.Identity;
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
    }
}