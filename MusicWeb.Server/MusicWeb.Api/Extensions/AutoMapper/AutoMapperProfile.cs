using AutoMapper;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Origins;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Models.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Extensions.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Artist, ArtistFullInfoDto>()
                .ForMember(prp => prp.Country, prop => prop.MapFrom(src => src.Country.Name))
                .ForMember(prp => prp.State, prop => prop.MapFrom(src => src.State.Name))
                .ForMember(prp => prp.City, prop => prop.MapFrom(src => src.City.Name));
            CreateMap<ArtistDto, Artist>();
            CreateMap<Artist, ArtistDto>();

            CreateMap<ArtistComment, ArtistCommentDto>();
            CreateMap<ArtistCommentDto, ArtistComment>();

            CreateMap<ArtistGenreDto, ArtistGenre>();
            CreateMap<ArtistGenre, ArtistGenreDto>()
                .ForMember(prp => prp.GenreName, prop => prop.MapFrom(src => src.Genre.Name));

            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();

            CreateMap<BandMemberDto, BandMember>();
            CreateMap<BandMember, BandMemberDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Member.Name));

            CreateMap<GenreDto, Genre>();

            CreateMap<CountryDto, Country>();
            CreateMap<StateDto, State>();
            CreateMap<CityDto, City>();

            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<City, CityDto>();
        }

    }
}
