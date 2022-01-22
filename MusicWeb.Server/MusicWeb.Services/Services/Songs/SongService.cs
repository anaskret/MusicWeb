using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Songs
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;
        public SongService(ISongRepository songRepository,
                           IMapper mapper,
                           IFileService fileService, 
                           IConfiguration configuration, 
                           AuthenticationStateProvider authenticationStateProvider, 
                           UserManager<ApplicationUser> userManager, 
                           IIdentityService identityService)
        {
            _songRepository = songRepository;
            _mapper = mapper;
            _fileService = fileService;
            _configuration = configuration;
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;
            _identityService = identityService;
        }

        public async Task AddAsync(Song entity)
        {
            await _songRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _songRepository.DeleteAsync(entity);
        }

        public async Task<List<Song>> GetAllAsync()
        {
            var entites = await _songRepository.GetAllAsync();
            return entites.ToList();
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _songRepository.GetByIdAsync(id);
        }

        public async Task<SongFullDataDto> GetSongFullDataByIdAsync(int id)
        {
            var song = await _songRepository.GetSongFullDataByIdAsync(id);
            return _mapper.Map<SongFullDataDto>(song);
        }

        public async Task<List<TopSongsWithRating>> GetTopSongsWithRatingAsync(int artistId)
        {
            return await _songRepository.GetTopSongsWithRatingsAsync(artistId);
        }

        public async Task UpdateAsync(Song entity)
        {
            await _songRepository.UpdateAsync(entity);
        }

        public async Task<List<Song>> GetSongsByAlbumIdAsync(int albumId)
        {
            var entities = await _songRepository.GetAllAsync(obj => obj.Where(prp => prp.AlbumId == albumId));
            return entities.ToList();
        }

        public async Task DeleteRangeAsync(List<Song> entities)
        {
            await _songRepository.DeleteRangeAsync(entities);
        }
        public async Task<SongRatingAverage> GetSongRatingAverage(int id)
        {
            return _mapper.Map<SongRatingAverage>(await _songRepository.GetSongAverageRating(id));
        }

        public async Task<List<SongRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = int.MaxValue, string searchString = "")
        {
            var response = await _songRepository.GetSongsPagedAsync(sortType, startDate, endDate, pageNum, pageSize, searchString);
            return response;
        }

        public async Task<IPagedList<Song>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue)
        {
            return await _songRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(prp => prp.Name.Contains(searchString));

                return query.OrderByDescending(prp => prp.Name);
            });
        }

        public async Task<List<SongRatingAverage>> GetPagedRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 5)
        {
            var response = await _songRepository.GetSongRankingAsync(sortType, pageNum, pageSize);
            return response;
        }
           
        public async Task UpdateImageAsync(List<SongFileUpdateDto> dtoList)
        {
            foreach(var dto in dtoList)
            {
                if (dto.ImageBytes.Length == 0)
                    continue;

                var filePath = await _fileService.UploadFile(dto.ImageBytes, FilePathConsts.SongPath);

                var entity = await GetByIdAsync(dto.SongId);
                entity.ImagePath = filePath;

                await _songRepository.UpdateAsync(entity);
            }
        }

        public async Task UploadAdminSongsImagesAsync(List<AdminSongCreateDto> dtoList, int albumId)
        {
            foreach(var item in dtoList)
            {
                var song = _mapper.Map<Song>(item);
                song.AlbumId = albumId;
                await AddAsync(song);
                item.Id = song.Id;
            }

            var uploadList = dtoList.Where(prp => prp.ImageBytes.Length > 0).ToList();

            if(uploadList.Count > 0)
                await UploadImageAsync(uploadList);
        }

        private async Task<string> UploadImageAsync(List<AdminSongCreateDto> dtos)
        {
            var client = await CreateClient();

            var apiEndpoint = _configuration.GetValue<string>("ApiEndpoint");
            var requestUri = apiEndpoint + "/" + ApiRoutes.Songs.UpdateImage;
            var convertedDtos = _mapper.Map<List<SongFileUpdateDto>>(dtos);

            HttpContent content = new StringContent(JsonSerializer.Serialize(convertedDtos), Encoding.UTF8, "application/json");
            var response = await client.PutAsync(requestUri, content);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return "";

            var path = await response.Content.ReadAsStringAsync();
            return path;
        }

        private async Task<HttpClient> CreateClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var token = await GetTokenAsync();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            return client;
        }

        private async Task<string> GetTokenAsync()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var email = authState.User.FindFirst(prp => prp.Type == ClaimTypes.Email);
            var user = await _userManager.FindByEmailAsync(email.Value);

            var token = await _identityService.GenerateNewTokenAsync(user);

            return token;
        }
    }
}
