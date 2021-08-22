using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Dtos.Artists;
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
        private readonly IArtistCommentService _artistCommentService;
        private readonly IArtistGenreService _artistGenreService;
        private readonly IGenreService _genreService;
        private readonly IAlbumService _albumService;
        private readonly IBandService _bandService;
        private readonly IOriginService _originService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public ArtistService(IArtistRepository artistRepository, IMapper mapper,
                             IArtistCommentService artistCommentService, IArtistGenreService artistGenreService,
                             IBandService bandService, IOriginService originService, IGenreService genreService, UserManager<ApplicationUser> userManager, IAlbumService albumService)
        {
            _artistRepository = artistRepository;
            _mapper = mapper;
            _bandService = bandService;
        }

        public async Task AddAsync(Artist entity)
        {
            await _artistRepository.AddAsync(entity);
        }

        public async Task<ArtistFullInfoDto> GetFullArtistInfoByIdAsync(int id)
        {
            //await Seed(id);
            var artist = await _artistRepository.GetFullArtistDataByIdAsync(id);

            if (artist == null)
                throw new ArgumentException("Artist not found");
            var mappedEntity = _mapper.Map<ArtistFullInfoDto>(artist);

            if (artist.IsBand)
            {
                var band = await _bandService.GetBandMembersAsync(mappedEntity.BandId.GetValueOrDefault());
                mappedEntity.Members = _mapper.Map<List<BandMemberDto>>(band);
            }


            return mappedEntity;
        }
    }
}
