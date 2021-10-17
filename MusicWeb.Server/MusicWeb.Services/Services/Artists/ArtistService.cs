using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
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

        public ArtistService(IArtistRepository artistRepository, IMapper mapper,
                             IBandService bandService, IFileService fileService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
            _fileService = fileService;
        }

        public async Task<Artist> GetByIdAsync(int id)
        {
            return await _artistRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Artist entity, byte[] imageBytes)
        {
            if (entity.IsBand && entity.IsIndividual)
                throw new ArgumentException("Artist cannot be both individual and a band at the same time");
            if (imageBytes.Length > 0)
                entity.ImagePath = await _fileService.UploadFile(imageBytes, FilePathConsts.ArtistPath);
            if (entity.IsIndividual || entity.IsBand)
            {
                await _artistRepository.AddAsync(entity);
                return;
            }

            var bandEntity = await GetByIdAsync(entity.BandId.GetValueOrDefault());
            if (bandEntity == null)
                throw new ArgumentException("Incorrect BandId");

            await _bandService.AddAsync(new BandMember { ArtistId = entity.Id, BandId = entity.BandId.GetValueOrDefault() });
        }

        public async Task<List<ArtistDto>> GetAllAsync()
        {
            return _mapper.Map<List<ArtistDto>>(await _artistRepository.GetAllAsync());
        }

        public async Task<ArtistFullInfoDto> GetFullArtistInfoByIdAsync(int id)
        {
            //await Seed(id);
            var artist = await _artistRepository.GetFullArtistDataByIdAsync(id);

            if (artist == null)
                throw new ArgumentException("Artist not found");
            var mappedEntity = _mapper.Map<ArtistFullInfoDto>(artist);

            var groupedGenres = artist.Albums.GroupBy(prp => prp.AlbumGenre);

            foreach(var genre in groupedGenres)
            {
                mappedEntity.Genres.Add(_mapper.Map<GenreDto>(genre.Key));
            }

            if (artist.IsBand)
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

        public async Task<List<Artist>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "")
        {
            var query = _artistRepository.GetAll();

            if(!string.IsNullOrEmpty(searchString))
                query = query.Where(prp => prp.Name.Contains(searchString));
            if (startDate > DateTime.MinValue)
                query = query.Where(prp => prp.EstablishmentDate > startDate);
            if (endDate < DateTime.MaxValue)
                query = query.Where(prp => prp.EstablishmentDate < endDate);

            switch (sortType)
            {
                case SortType.AlphabeticAsc: query.OrderBy(prp => prp.Name);
                    break;
                case SortType.AlphabeticDesc: query.OrderByDescending(prp => prp.Name);
                    break;
                //case SortType.PopularityAsc: query.OrderBy(prp => prp.)
                default: query.OrderBy(prp => prp.Name);
                    break;
            }

            query.Skip(pageNum * pageSize);
            query.Take(pageSize);

            return await query.ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            await _artistRepository.DeleteAsync(entity);
        }
    }
}
