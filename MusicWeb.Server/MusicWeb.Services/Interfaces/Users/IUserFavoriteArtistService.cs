﻿using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Users
{
    public interface IUserFavoriteArtistService
    {
        Task<IList<UserFavoriteArtist>> GetAllByUserIdAsync(string userId);
        Task CreateAsync(UserFavoriteArtist model);
        Task DeleteAsync(int id);
        Task DeleteRangeByUserIdAsync(string userId);
    }
}
