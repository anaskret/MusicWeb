using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Origins;
using System;
using System.Collections.Generic;
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

        public ArtistService(IArtistRepository artistRepository, IMapper mapper,
                             IBandService bandService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
        }

        public async Task AddAsync(Artist entity)
        {
            await _artistRepository.AddAsync(entity);

            if (!entity.IsIndividual)
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
    }
}
