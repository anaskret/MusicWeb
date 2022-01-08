using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
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
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Origins;
using MusicWeb.Services.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

        public ArtistService(IArtistRepository artistRepository,
                             IMapper mapper,
                             IBandService bandService,
                             IFileService fileService,
                             UserManager<ApplicationUser> userManager, 
                             ISongService songService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
            _fileService = fileService;
            _userManager = userManager;
            _songService = songService;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _artistRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Artist entity, byte[] imageBytes)
        {
            if (imageBytes.Length > 0)
                entity.ImagePath = await _fileService.UploadFile(imageBytes, FilePathConsts.ArtistPath);

            await _artistRepository.AddAsync(entity);
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

        public async Task UpdateAsync(Artist entity)
        {
            await _artistRepository.UpdateAsync(entity);
        }
        
        public async Task UpdateImageAsync(ArtistFileUpdateDto dto)
        {
            if (dto.ImageBytes.Length == 0)
                throw new ArgumentException("File is empty");

            _fileService.DeleteFile(Path.GetFileName(dto.ImagePath), FilePathConsts.ArtistPath);
            var filePath = await _fileService.UploadFile(dto.ImageBytes, FilePathConsts.ArtistPath);

            var artist = await GetByIdAsync(dto.ArtistId);
            artist.ImagePath = filePath;

            await UpdateAsync(artist);
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

        public async Task DeleteAsync(int id)
        {
            //add related objects deletion

            var entity = await GetByIdAsync(id);
            await _artistRepository.DeleteAsync(entity);
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
            await _userManager.CreateAsync(userEntity);
        }

        public async Task UpdateArtistAsync(Artist entity)
        {
            if(entity.Type == ArtistType.BandMember)
                await _bandService.DeleteAsync(entity.BandId.GetValueOrDefault(), entity.Id);

            await _artistRepository.UpdateAsync(entity);
        }

        public async Task<ArtistRatingAverage> GetArtistRatingAverage(int id)
        {
            return _mapper.Map<ArtistRatingAverage>(await _artistRepository.GetArtistAverageRating(id));
        }
    }
}
