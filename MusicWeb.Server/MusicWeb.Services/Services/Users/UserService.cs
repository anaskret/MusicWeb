using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserFavoriteAlbumService _userFavoriteAlbumService;
        private readonly IUserFavoriteArtistService _userFavoriteArtistService;
        private readonly IUserFavoriteSongService _userFavoriteSongService;
        private readonly IUserObservedArtistService _userObservedArtistService;
        private readonly IUserFriendService _userFriendService;
        private readonly IArtistService _artistService;
        private readonly IArtistRatingService _artistRatingService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository,
            IUserFavoriteAlbumService userFavoriteAlbumService,
            IUserFavoriteArtistService userFavoriteArtistService,
            IUserFavoriteSongService userFavoriteSongService,
            IUserObservedArtistService userObservedArtistService,
            IUserFriendService userFriendService,
            IArtistService artistService,
            IArtistRatingService artistRatingService, 
            UserManager<ApplicationUser> userManager)
        {
            _userRepository = userRepository;
            _userFavoriteAlbumService = userFavoriteAlbumService;
            _userFavoriteArtistService = userFavoriteArtistService;
            _userFavoriteSongService = userFavoriteSongService;
            _userObservedArtistService = userObservedArtistService;
            _userFriendService = userFriendService;
            _artistService = artistService;
            _artistRatingService = artistRatingService;
            _userManager = userManager;
        }

        public async Task DeleteAsync(string id)
        {
            await _userFavoriteAlbumService.DeleteRangeByUserIdAsync(id);
            await _userFavoriteArtistService.DeleteRangeByUserIdAsync(id);
            await _userFavoriteSongService.DeleteRangeByUserIdAsync(id);
            await _userObservedArtistService.DeleteRangeByUserIdAsync(id);
            await _userFriendService.DeleteRangeByUserIdAsync(id);
            await _artistRatingService.DeleteRangeByUserIdAsync(id);

            var user = await _userManager.FindByIdAsync(id);

            //if (user.Type == UserType.Artist)
            //    await _artistService.DeleteAsync(user.ArtistId.GetValueOrDefault());

            await _userManager.DeleteAsync(user);
        }

        public async Task<IList<ApplicationUser>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<IPagedList<ApplicationUser>> GetAllPagedAsync(string searchString, UserType userType, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            return _userRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(prp => prp.UserName.Contains(searchString));
                if (userType != UserType.All)
                    query = query.Where(prp => prp.Type == userType);

                return query.OrderByDescending(prp => prp.UserName);
            }, pageIndex, pageSize);
        }

        public async Task<ApplicationUser> GetUserProfileById(string id)
        {
            var entity = await _userRepository.GetUserByIdAsync(id);
            return entity;
        }
    }
}
