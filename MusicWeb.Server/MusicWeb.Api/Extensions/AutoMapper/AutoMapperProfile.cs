using AutoMapper;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Albums.Create;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Artists.Create;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Genres.Create;
using MusicWeb.Models.Dtos.Origins;
using MusicWeb.Models.Dtos.Origins.Create;
using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Identity;
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
                .ForMember(prp => prp.Country, prop => prop.MapFrom(src => src.City.State.Country.Name))
                .ForMember(prp => prp.State, prop => prop.MapFrom(src => src.City.State.Name))
                .ForMember(prp => prp.City, prop => prop.MapFrom(src => src.City.Name));
            CreateMap<ArtistDto, Artist>();
            CreateMap<CreateArtistDto, Artist>();
            CreateMap<Artist, ArtistDto>();

            CreateMap<ArtistComment, ArtistCommentDto>();
            CreateMap<ArtistCommentDto, ArtistComment>();

            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();
            CreateMap<CreateAlbumDto, Album>();

            CreateMap<BandMemberDto, BandMember>();
            CreateMap<BandMember, BandMemberDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Member.Name));

            CreateMap<GenreDto, Genre>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<CountryDto, Country>();
            CreateMap<CreateCountryDto, Country>();
            CreateMap<StateDto, State>();
            CreateMap<CreateStateDto, State>();
            CreateMap<CityDto, City>();
            CreateMap<CreateCityDto, City>();

            CreateMap<Country, CountryDto>();
            CreateMap<State, StateDto>();
            CreateMap<City, CityDto>();

            CreateMap<ApplicationUser, UserDto>();
            CreateMap<UserFavoriteArtist, UserFavoriteDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Artist.Name))
                .ForMember(prp => prp.FavoriteId, prop => prop.MapFrom(src => src.ArtistId));
            CreateMap<UserFavoriteAlbum, UserFavoriteDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Album.Name))
                .ForMember(prp => prp.FavoriteId, prop => prop.MapFrom(src => src.AlbumId));
            CreateMap<UserFavoriteSong, UserFavoriteDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Song.Name))
                .ForMember(prp => prp.FavoriteId, prop => prop.MapFrom(src => src.SongId));
            CreateMap<UserFriend, UserFriendDto>()
                .ForMember(prp => prp.FriendName, prop => prop.MapFrom(src => src.Friend.UserName));
            CreateMap<UserFriendDto, UserFriend>();

            CreateMap<UserFavoriteDto, UserFavoriteArtist>()
                .ForMember(prp => prp.ArtistId, prop => prop.MapFrom(src => src.FavoriteId));
            CreateMap<UserFavoriteDto, UserFavoriteAlbum>()
                .ForMember(prp => prp.AlbumId, prop => prop.MapFrom(src => src.FavoriteId));
            CreateMap<UserFavoriteDto, UserFavoriteSong>()
                .ForMember(prp => prp.SongId, prop => prop.MapFrom(src => src.FavoriteId));

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<CreatePostDto, Post>();
        }

    }
}
