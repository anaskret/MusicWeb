﻿using AutoMapper;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Dtos.Albums.Create;
using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Artists.Create;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Genres.Create;
using MusicWeb.Models.Dtos.Origins;
using MusicWeb.Models.Dtos.Origins.Create;
using MusicWeb.Models.Dtos.Posts;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Dtos.Ratings;
using MusicWeb.Models.Dtos.Users;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MusicWeb.Models.Dtos.Chats.Base;
using MusicWeb.Models.Dtos.Chats;

namespace MusicWeb.Api.Extensions.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Artist, ArtistFullInfoDto>()
                .ForMember(prp => prp.Country, prop => prop.MapFrom(src => src.Country.Name));
            CreateMap<ArtistDto, Artist>();
            CreateMap<CreateArtistDto, Artist>();
            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistRatingAverage, ArtistDto>();

            CreateMap<ArtistComment, ArtistCommentDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName));
            CreateMap<ArtistCommentDto, ArtistComment>();
            CreateMap<BaseArtistCommentDto, ArtistComment>();

            CreateMap<Album, AlbumDto>();
            //    .ForMember(prp => prp.Rating, obj => obj.MapFrom(src => src.AlbumRatings));
            CreateMap<AlbumDto, Album>();
            CreateMap<CreateAlbumDto, Album>();
            CreateMap<Album, CreateAlbumDto>();
            CreateMap<Album, AlbumFullDataDto>()
                .ForMember(prp => prp.AlbumReviews, obj => obj.MapFrom(src => src.AlbumReviews));
            CreateMap<AlbumFullDataDto, Album>();
            CreateMap<AlbumRatingAverage, AlbumDto>();


            CreateMap<AlbumReview, AlbumReviewDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName));
            CreateMap<AlbumReviewDto, AlbumReview>();
            CreateMap<CreateAlbumReviewDto, AlbumReview>();
            CreateMap<AlbumReviewFullDataDto, AlbumReview>();
            CreateMap<AlbumReview, AlbumReviewFullDataDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName))
                .ForMember(prp => prp.Artist, obj => obj.MapFrom(src => src.Album.Artist.Name));
            CreateMap<AlbumReviewRating, AlbumReview>();
            CreateMap<AlbumReview, AlbumReviewRating>();
            CreateMap<AlbumReviewRating, AlbumReviewDto>();
            CreateMap<AlbumReviewDto, AlbumReviewRating>();

            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();
            CreateMap<CreateSongDto, Song>();
            CreateMap<Song, CreateSongDto>();
            CreateMap<SongFullDataDto, Song>();
            CreateMap<Song, SongFullDataDto>();
            CreateMap<SongRatingAverage, SongDto>();

            CreateMap<TopSongsWithRating, SongWithRatingDto>();

            CreateMap<SongReview, SongReviewDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName));
            CreateMap<SongReviewDto, SongReview>();
            CreateMap<SongReview, CreateSongReviewDto>();
            CreateMap<SongReviewFullDataDto, SongReview>();
            CreateMap<SongReview, SongReviewFullDataDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName))
                .ForMember(prp => prp.AlbumName, obj => obj.MapFrom(src => src.Song.Album.Name))
                .ForMember(prp => prp.ArtistName, obj => obj.MapFrom(src => src.Song.Album.Artist.Name));
            CreateMap<SongReviewRating, SongReview>();
            CreateMap<SongReview, SongReviewRating>();
            CreateMap<SongReviewRating, SongReviewDto>();
            CreateMap<SongReviewDto, SongReviewRating>();

            CreateMap<BandMemberDto, BandMember>();
            CreateMap<BandMember, BandMemberDto>()
                .ForMember(prp => prp.Name, prop => prop.MapFrom(src => src.Member.Name));

            CreateMap<GenreDto, Genre>();
            CreateMap<CreateGenreDto, Genre>();
            CreateMap<Genre, GenreDto>();

            CreateMap<CountryDto, Country>();
            CreateMap<CreateCountryDto, Country>();

            CreateMap<Country, CountryDto>();

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
            CreateMap<UserFavoriteDto, UserObservedArtist>()
                .ForMember(prp => prp.ObservedDate, obj => obj.MapFrom(src => src.FavoriteDate))
                .ForMember(prp => prp.ArtistId, obj => obj.MapFrom(src => src.FavoriteId));
            CreateMap<UserObservedArtist, UserFavoriteDto>()
                .ForMember(prp => prp.FavoriteDate, obj => obj.MapFrom(src => src.ObservedDate))
                .ForMember(prp => prp.FavoriteId, obj => obj.MapFrom(src => src.ArtistId))
                .ForMember(prp => prp.Name, obj => obj.MapFrom(src => src.Artist.Name));

            CreateMap<UserFriend, UserFriendDto>()
                .ForMember(prp => prp.FriendName, prop => prop.MapFrom(src => src.Friend.UserName));
            CreateMap<UserFriendDto, UserFriend>();
            CreateMap<CreateUserFriendDto, UserFriend>();

            CreateMap<UserFavoriteDto, UserFavoriteArtist>()
                .ForMember(prp => prp.ArtistId, prop => prop.MapFrom(src => src.FavoriteId));
            CreateMap<UserFavoriteDto, UserFavoriteAlbum>()
                .ForMember(prp => prp.AlbumId, prop => prop.MapFrom(src => src.FavoriteId));
            CreateMap<UserFavoriteDto, UserFavoriteSong>()
                .ForMember(prp => prp.SongId, prop => prop.MapFrom(src => src.FavoriteId));

            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
            CreateMap<CreatePostDto, Post>();
            CreateMap<UserAndArtistPost, GetPostDto>();
            CreateMap<PostComment, GetPostCommentDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName));
            CreateMap<CreatePostCommentDto, PostComment>();
            CreateMap<PostCommentDto, PostComment>();

            CreateMap<ArtistRating, ArtistRatingDto>();
            CreateMap<ArtistRatingDto, ArtistRating>();
            CreateMap<CreateArtistRatingDto, ArtistRating>();

            CreateMap<AlbumRating, AlbumRatingDto>();
            CreateMap<AlbumRatingDto, AlbumRating>();
            CreateMap<CreateAlbumRatingDto, AlbumRating>();            
            
            CreateMap<SongRating, SongRatingDto>();
            CreateMap<SongRatingDto, SongRating>();
            CreateMap<CreateSongRatingDto, SongRating>();

            CreateMap<BaseChatDto, Chat>();
            CreateMap<ChatDto, Chat>();
            CreateMap<Chat, ChatWithUserNamesDto>()
                .ForMember(prp => prp.UserName, obj => obj.MapFrom(src => src.User.UserName))
                .ForMember(prp => prp.FriendName, obj => obj.MapFrom(src => src.Friend.UserName));

            CreateMap<Message, MessageDto>()
                .ForMember(prp => prp.SenderName, obj => obj.MapFrom(src => src.Sender != null ? src.Sender.UserName : ""));
        }

    }
}
