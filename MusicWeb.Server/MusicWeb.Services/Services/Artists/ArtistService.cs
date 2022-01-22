using AutoMapper;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Identity;
using MusicWeb.Services.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Artists
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IBandService _bandService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISongService _songService;
        private readonly IConfiguration _configuration;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly IIdentityService _identityService;
        private readonly IEmailSender _emailSender;

        public ArtistService(IArtistRepository artistRepository,
                             IMapper mapper,
                             IBandService bandService,
                             IFileService fileService,
                             UserManager<ApplicationUser> userManager,
                             ISongService songService,
                             IConfiguration configuration,
                             AuthenticationStateProvider authenticationStateProvider,
                             IIdentityService identityService, 
                             IEmailSender emailSender)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
            _fileService = fileService;
            _userManager = userManager;
            _songService = songService;
            _configuration = configuration;
            _authenticationStateProvider = authenticationStateProvider;
            _identityService = identityService;
            _emailSender = emailSender;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _artistRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Artist entity, byte[] imageBytes)
        {
            await _artistRepository.AddAsync(entity);

            await ArtistImageUploadInitalizationAsync(entity, imageBytes);

            if (entity.Type != ArtistType.BandMember)
                return;

            var bandId = entity.BandId.GetValueOrDefault();
            var bandEntity = await GetByIdAsync(bandId);
            if (bandEntity == null)
                throw new ArgumentException("Incorrect BandId");

            await _bandService.AddAsync(new BandMember { ArtistId = entity.Id, BandId = entity.BandId.GetValueOrDefault() });
        }

        public async Task<IList<Artist>> GetAllAsync()
        {
            return await _artistRepository.GetAllAsync();
        }

        public async Task UpdateAsync(Artist entity)
        {
            await _artistRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);

            if (entity.Type == ArtistType.BandMember)
                await _bandService.DeleteAsync(entity.BandId.GetValueOrDefault(), entity.Id);

            await _artistRepository.DeleteAsync(entity);
        }

        public async Task<ArtistFullInfoDto> GetFullArtistInfoByIdAsync(int id)
        {
            var artist = await _artistRepository.GetFullArtistDataByIdAsync(id);

            if (artist == null)
                throw new ArgumentException("Artist not found");
            var mappedEntity = _mapper.Map<ArtistFullInfoDto>(artist);

            var groupedGenres = artist.Albums.GroupBy(prp => prp.AlbumGenre);

            foreach(var genre in groupedGenres)
            {
                mappedEntity.Genres.Add(_mapper.Map<GenreDto>(genre.Key));
            }

            if (artist.Type == ArtistType.Band)
            {
                var band = await _bandService.GetBandMembersAsync(mappedEntity.Id);
                mappedEntity.Members = _mapper.Map<List<BandMemberDto>>(band);
            }

            mappedEntity.Songs.AddRange(_mapper.Map<List<SongWithRatingDto>>(await _songService.GetTopSongsWithRatingAsync(id)));

            return mappedEntity;
        }
        
        public async Task<string> UpdateImageAsync(ArtistFileUpdateDto dto)
        {
            if (dto.ImageBytes.Length == 0)
                throw new ArgumentException("File is empty");

            var filePath = await _fileService.UploadFile(dto.ImageBytes, FilePathConsts.ArtistPath);

            var artist = await GetByIdAsync(dto.ArtistId);
            artist.ImagePath = filePath;

            await _artistRepository.UpdateAsync(artist);

            return filePath;
        }

        public async Task<List<ArtistRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = int.MaxValue, string searchString = "")
        {
            var response = await _artistRepository.GetArtistsPagedAsync(sortType, startDate, endDate, pageNum, pageSize, searchString);
            return response;
        }

        public async Task<IPagedList<Artist>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue)
        {
            return await _artistRepository.GetAllPagedAsync(query =>
            {
                if (!string.IsNullOrEmpty(searchString))
                    query = query.Where(prp => prp.Name.Contains(searchString));

                return query.OrderByDescending(prp => prp.Name);
            });
        }

        public async Task<IList<Artist>> GetAllBandsAsync()
        {
            return await _artistRepository.GetAllAsync(entity => entity.Where(prp => prp.Type == ArtistType.Band));
        }

        public async Task AddArtistAsync(ArtistWithUserModel model)
        {
            var userByEmail = await _userManager.FindByEmailAsync(model.Email);
            var userByUserName = await _userManager.FindByNameAsync(model.UserName);

            if (userByEmail != null)
                throw new ArgumentException("Error User with given email already exists!");
            if (userByUserName != null)
                throw new ArgumentException("Error User with given username already exists!");

            var artistEntity = _mapper.Map<Artist>(model);

            if (model.Image != null)
            {
                var fileBytes = new byte[model.Image.Size];
                await model.Image.OpenReadStream(int.MaxValue).ReadAsync(fileBytes);
                await AddAsync(artistEntity, fileBytes);
            }
            else
                await AddAsync(artistEntity, Array.Empty<byte>());

            var userEntity = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.Name,
                LastName = string.IsNullOrEmpty(model.LastName) ? model.LastName : model.Name,
                BirthDate = model.EstablishmentDate,
                ArtistId = artistEntity.Id,
                Type = UserType.Artist
            };

            var generator = new PasswordGeneratorService();
            string password = generator.Generate();

            await _userManager.CreateAsync(userEntity, password);

            await _emailSender.SendEmailAsync(model.Email, "New user created", $"Your email was connected to an artist! UserName: {model.UserName}, Password: {password}");
        }

        public async Task UpdateArtistAsync(Artist entity, byte[] imageBytes)
        {
            await ArtistImageUploadInitalizationAsync(entity, imageBytes);
            await UpdateAsync(entity);
        }

        public async Task<ArtistRatingAverage> GetArtistRatingAverageAsync(int id)
        {
            return _mapper.Map<ArtistRatingAverage>(await _artistRepository.GetArtistAverageRating(id));
        }

        private async Task ArtistImageUploadInitalizationAsync(Artist entity, byte[] imageBytes)
        {
            if (imageBytes.Length > 0)
            {
                entity.ImagePath = await UploadImageAsync(entity.Id, imageBytes);
                await UpdateAsync(entity);
            }
        }

        private async Task<string> UploadImageAsync(int artistId, byte[] imageBytes)
        {
            var client = await CreateClient();

            var apiEndpoint = _configuration.GetValue<string>("ApiEndpoint");
            var requestUri = apiEndpoint + "/" + ApiRoutes.Artists.UpdateImage;
            var dto = new ArtistFileUpdateDto { ArtistId = artistId, ImageBytes = imageBytes };

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
        public async Task<List<ArtistRatingAverage>> GetPagedRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 5)
        {
            var response = await _artistRepository.GetArtistRankingAsync(sortType, pageNum, pageSize);
            return response;
        }
        public async Task<ArtistRatingAverage> GetArtistRatingAverage(int id)
        {
            return _mapper.Map<ArtistRatingAverage>(await _artistRepository.GetArtistAverageRating(id));
        }

        public async Task<bool> DoesArtistExistsByNameAsync(string name)
        {
            return await _artistRepository.DoesArtistWithNameExistsAsync(name);   
        }
    }
}
