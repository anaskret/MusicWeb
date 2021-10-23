using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Origins;
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

        public ArtistService(IArtistRepository artistRepository, IMapper mapper,
                             IBandService bandService, IFileService fileService, UserManager<ApplicationUser> userManager)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
            _fileService = fileService;
            _userManager = userManager;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _artistRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Artist entity, byte[] imageBytes)
        {
            if (imageBytes.Length > 0)
                entity.ImagePath = await _fileService.UploadFile(imageBytes, FilePathConsts.ArtistPath);
            if (entity.Type != ArtistType.BandMember)
            {
                await _artistRepository.AddAsync(entity);
                return;
            }

            var bandEntity = await GetByIdAsync(entity.BandId.GetValueOrDefault());
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

        public async Task<List<ArtistRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var response = await _artistRepository.GetArtistsPagedAsync(sortType, startDate, endDate, pageNum, pageSize, searchString);
            return response;
        }

        public async Task DeleteAsync(int id)
        {
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
                throw new ArgumentException("User with given email already exists!");
            if (userByUserName != null)
                throw new ArgumentException("User with given username already exists!");

            var userEntity = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.Name,
                LastName = string.IsNullOrEmpty(model.LastName) ? model.LastName : model.Name,
                BirthDate = model.EstablishmentDate,
                Type = UserType.Artist
            };
            await _userManager.CreateAsync(userEntity);

            var artistEntity = _mapper.Map<Artist>(model);
            var fileBytes = new byte[model.Image.Size];
            await model.Image.OpenReadStream(int.MaxValue).ReadAsync(fileBytes);

            await AddAsync(artistEntity, fileBytes);
        }
    }
}
