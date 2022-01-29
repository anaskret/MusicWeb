using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IFileService _fileService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(IUserRepository userRepository,
            IUserFavoriteAlbumService userFavoriteAlbumService,
            IUserFavoriteArtistService userFavoriteArtistService,
            IUserFavoriteSongService userFavoriteSongService,
            IUserObservedArtistService userObservedArtistService,
            IUserFriendService userFriendService,
            IArtistService artistService,
            IArtistRatingService artistRatingService,
            UserManager<ApplicationUser> userManager, IFileService fileService)
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
            _fileService = fileService;
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

            if (user == null)
                return;

            if (user.Type == UserType.Artist)
                await _artistService.DeleteAsync(user.ArtistId.GetValueOrDefault());

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

        public async Task UpdateEmailAsync(UpdateEmailDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
                throw new ArgumentException("User not found");

            var checkEmail = await _userManager.FindByEmailAsync(dto.Email);
            if (checkEmail != null)
                throw new ArgumentException("User with that email already exists!");

            user.Email = dto.Email;
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdateImageAsync(UserImageDto dto)
        {
            if (dto.ImageBytes.Length == 0)
                throw new ArgumentException("File is empty");

            _fileService.DeleteFile(dto.ImagePath, FilePathConsts.UserPath);
            var filePath = await _fileService.UploadFile(dto.ImageBytes, FilePathConsts.UserPath);

            var user = await _userManager.FindByIdAsync(dto.UserId);
            user.ImagePath = filePath;

            await _userManager.UpdateAsync(user);
        }

        public async Task UpdateNameAsync(UpdateNameDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
                throw new ArgumentException("User not found");

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            await _userManager.UpdateAsync(user);
        }

        public async Task UpdatePasswordAsync(UpdatePasswordDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.Id);
            if (user == null)
                throw new ArgumentException("User not found");

            if (!await _userManager.CheckPasswordAsync(user, dto.OldPassword))
                throw new ArgumentException("Incorrect old password");

            await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        }
    }
}
