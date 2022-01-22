using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Identity;
using MusicWeb.Services.Interfaces.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Albums
{
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMapper _mapper;
        private readonly IPostService _postService;
        private readonly ISongService _songService;
        private readonly IConfiguration _configuration;
        private readonly IFileService _fileService;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;

        public AlbumService(IAlbumRepository albumRepository,
                            IMapper mapper,
                            IPostService postService,
                            ISongService songService,
                            IConfiguration configuration,
                            IFileService fileService, 
                            AuthenticationStateProvider authenticationStateProvider,
                            UserManager<ApplicationUser> userManager, 
                            IIdentityService identityService)
        {
            _albumRepository = albumRepository;
            _mapper = mapper;
            _postService = postService;
            _songService = songService;
            _configuration = configuration;
            _fileService = fileService;
            _authenticationStateProvider = authenticationStateProvider;
            _userManager = userManager;
            _identityService = identityService;
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await _albumRepository.GetByIdNoTrackingAsync(id);
        }

        public async Task<List<Album>> GetAllAsync()
        {
            var entites = await _albumRepository.GetAllAsync(obj => obj.Where(prp => prp.IsConfirmed).Include(prp => prp.Artist).Include(prp => prp.AlbumGenre).AsNoTracking());
            return entites.ToList();
        }

        public async Task<List<Album>> GetAllFilteredAsync(int filter)
        {
            var entites = await _albumRepository.GetAllAsync(query =>
            {
                if (filter == 1)
                    query = query.Where(prp => !prp.IsConfirmed);
                if (filter == 2)
                    query = query.Where(prp => prp.IsConfirmed);

                query = query.Include(prp => prp.Artist).Include(prp => prp.AlbumGenre).AsNoTracking();
                return query;
            });

            return entites.ToList();
        }

        public async Task<List<Album>> GetAllUnconfirmedAsync()
        {
            var entites = await _albumRepository.GetAllAsync(obj => obj.Where(prp => !prp.IsConfirmed).Include(prp => prp.Artist).Include(prp => prp.AlbumGenre));
            return entites.ToList();
        }

        public async Task AddAsync(Album entity)
        {
            await _albumRepository.AddAsync(entity);

            await _postService.AddAsync(new Post { AlbumId = entity.Id, ArtistPosterId = entity.ArtistId, CreateDate = DateTime.Now });
        }

        public async Task UpdateAsync(Album entity)
        {
            await _albumRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var songEntities = await _songService.GetSongsByAlbumIdAsync(id);
            await _songService.DeleteRangeAsync(songEntities);

            var entity = await GetByIdAsync(id);
            await _albumRepository.DeleteAsync(entity);
        }

        public async Task ConfirmAlbumAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsConfirmed = true;

            await _albumRepository.UpdateAsync(entity);
        }

        public async Task<AlbumFullDataDto> GetFullAlbumDataByIdAsync(int id)
        {
            var album = await _albumRepository.GetFullAlbumDataByIdAsync(id);
            return _mapper.Map<AlbumFullDataDto>(album);
        }

        public async Task<List<Album>> GetUnconfirmedAlbumsAsync()
        {
            var entities = await _albumRepository.GetAllAsync(obj => obj.Where(prp => prp.IsConfirmed));
            return entities.ToList();
        }

        public async Task<AlbumRatingAverage> GetAlbumRatingAverage(int id)
        {
            return _mapper.Map<AlbumRatingAverage>(await _albumRepository.GetAlbumAverageRating(id));
        }
        public async Task<List<AlbumRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = int.MaxValue, string searchString = "")
        {
            var response = await _albumRepository.GetAlbumsPagedAsync(sortType, startDate, endDate, pageNum, pageSize, searchString);
            return response;
        }

        public async Task<IPagedList<Album>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue)
        {
            return await _albumRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(prp => prp.Name.Contains(searchString));

                return query.OrderByDescending(prp => prp.Name);
            });
        }

        public async Task<string> UpdateImageAsync(AlbumFileUpdateDto dto)
        {
            if (dto.ImageBytes.Length == 0)
                throw new ArgumentException("File is empty");

            var filePath = await _fileService.UploadFile(dto.ImageBytes, FilePathConsts.AlbumPath);

            var artist = await GetByIdAsync(dto.AlbumId);
            artist.ImagePath = filePath;

            await _albumRepository.UpdateAsync(artist);

            return filePath;
        }

        public async Task CreateAdminAlbum(AdminAlbumCreateDto dto)
        {
            dto.Duration = dto.Songs.Sum(prp => prp.Length);
            
            var entity = _mapper.Map<Album>(dto);

            await AddAsync(entity);

            if (dto.ImageBytes.Length > 0)
            { 
                await UploadImageAsync(entity.Id, dto.ImageBytes);
            }

            await _songService.UploadAdminSongsImagesAsync(dto.Songs, entity.Id);
        }

        private async Task<string> UploadImageAsync(int albumId, byte[] imageBytes)
        {
            var client = await CreateClient();

            var apiEndpoint = _configuration.GetValue<string>("ApiEndpoint");
            var requestUri = apiEndpoint + "/" + ApiRoutes.Albums.UpdateImage;
            var dto = new AlbumFileUpdateDto { AlbumId = albumId, ImageBytes = imageBytes };

            HttpContent content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
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
        public async Task<List<AlbumRatingAverage>> GetPagedRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 5)
        {
            var response = await _albumRepository.GetAlbumRankingAsync(sortType, pageNum, pageSize);
            return response;
        }

        public async Task AddRangeAsync(List<Album> entities)
        {
            await _albumRepository.AddRangeAsync(entities);
        }
    }
}
