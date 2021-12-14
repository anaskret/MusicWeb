using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Api.Extensions
{
    public class ApiRoutes
    {
        private const string Root = "api";

        public static class Artists
        {
            public const string GetFullData = Root + "/artistdata/{id}";
            public const string Create = Root + "/artists";
            public const string GetAllPagedSearchString = Root + "/artists/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}/{searchString}";
            public const string GetAllPaged = Root + "/artists/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}";
            public const string Update = Root + "/artists";
            public const string UpdateImage = Root + "/artists/images";
            public const string GetById = Root + "/artists/{id}";
            public const string Delete = Root + "/artists/{id}";
        }

        public static class ArtistComments
        {
            public const string Create = Root + "/artistcomments";
            public const string GetAllById = Root + "/artistcomments/{id}";
            public const string Update = Root + "/artistcomments";
            public const string GetById = Root + "/artistcomments/singlecomment/{id}";
            public const string Delete = Root + "/artistcomments/{id}";
        }

        public static class BandMembers
        {
            public const string Create = Root + "/bandmembers";
            public const string GetAll = Root + "/bandmembers";
            public const string Update = Root + "/bandmembers";
            public const string GetById = Root + "/bandmembers/{id}";
            public const string Delete = Root + "/bandmembers/{id}";
        }

        public static class Albums
        {
            public const string Create = Root + "/albums";
            public const string GetAll = Root + "/albums";
            public const string Update = Root + "/albums";
            public const string GetById = Root + "/albums/{id}";
            public const string Delete = Root + "/albums/{id}";
            public const string GetFullData = Root + "/albumsdata/{id}";
            public const string GetAlbumRatingAverage = Root + "/albumaveragerating/{id}";
            public const string GetAllPagedSearchString = Root + "/albums/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}/{searchString}";
            public const string GetAllPaged = Root + "/albums/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}";

        }

        public static class AlbumReviews
        {
            public const string Create = Root + "/albumreviews";
            public const string GetAll = Root + "/albumreviews";
            public const string Update = Root + "/albumreviews";
            public const string GetById = Root + "/albumreviews/{id}";
            public const string Delete = Root + "/albumreviews/{id}";
            public const string GetFullData = Root + "/albumreviewsdata/{id}";

        }


        public static class Songs
        {
            public const string Create = Root + "/songs";
            public const string GetAll = Root + "/songs";
            public const string Update = Root + "/songs";
            public const string GetById = Root + "/songs/{id}";
            public const string Delete = Root + "/songs/{id}";
            public const string GetFullData = Root + "/songsdata/{id}";
            public const string GetSongRatingAverage = Root + "/songaveragerating/{id}";
            public const string GetAllPagedSearchString = Root + "/songs/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}/{searchString}";
            public const string GetAllPaged = Root + "/songs/{pageNum}/{pageSize}/{sortType}/{createDateStart}/{createDateEnd}";

        }

        public static class SongReviews
        {
            public const string Create = Root + "/songreviews";
            public const string GetAll = Root + "/songreviews";
            public const string Update = Root + "/songreviews";
            public const string GetById = Root + "/songreviews/{id}";
            public const string Delete = Root + "/songreviews/{id}";
            public const string GetFullData = Root + "/songreviewsdata/{id}";

        }

        public static class Genres
        {
            public const string Create = Root + "/genres";
            public const string GetAll = Root + "/genres";
            public const string Update = Root + "/genres";
            public const string GetById = Root + "/genres/{id}";
            public const string Delete = Root + "/genres/{id}";
        }

        public static class ArtistGenres
        {
            public const string Create = Root + "/artistgenres";
            public const string GetAll = Root + "/artistgenres";
            public const string Update = Root + "/artistgenres";
            public const string GetById = Root + "/artistgenres/{id}";
            public const string Delete = Root + "/artistgenres/{id}";
        }

        public static class Origins
        {
            public const string CreateCountry = Root + "/origins/countries";
            public const string UpdateCountry = Root + "/origins/countries";
            public const string GetAllCountries = Root + "/origins/countries";
            public const string DeleteCountry = Root + "/origins/countries/{id}";
            public const string GetCountryById = Root + "/origins/countries/{id}";
            public const string GetCountryStates = Root + "/origins/countrystates/{id}";

            public const string CreateState = Root + "/origins/states";
            public const string UpdateState = Root + "/origins/states";
            public const string GetAllStates = Root + "/origins/states";
            public const string DeleteState = Root + "/origins/states/{id}";
            public const string GetStateById = Root + "/origins/states/{id}";
            public const string GetStateCities = Root + "/origins/statecities/{id}";

            public const string CreateCity = Root + "/origins/cities";
            public const string UpdateCity = Root + "/origins/cities";
            public const string GetAllCities = Root + "/origins/cities";
            public const string DeleteCity = Root + "/origins/cities/{id}";
            public const string GetCityById = Root + "/origins/cities/{id}";
        }

        public static class Identity
        {
            public const string Register = Root + "/register";
            public const string Login = Root + "/login";
        }

        public static class Users
        {
            public const string GetUserProfile = Root + "/users/{id}";
            public const string GetAll = Root + "/users";
            public const string UpdatePassword = Root + "/users/password";
            public const string UpdateNames = Root + "/users/names";
            public const string UpdateEmail = Root + "/users/email";
            public const string UpdateImage = Root + "/users/image";
        }

        public static class UserFavoriteArtists
        {
            public const string Create = Root + "/userfavoriteartists";
            public const string GetAll = Root + "/userfavoriteartistsbyuser/{id}";
            public const string GetById = Root + "/userfavoriteartists/{id}";
            public const string Delete = Root + "/userfavoriteartists/{id}";
        }

        public static class UserFavoriteAlbums
        {
            public const string Create = Root + "/userfavoritealbums";
            public const string GetAll = Root + "/userfavoritealbumsbyuser/{userId}";
            public const string GetById = Root + "/userfavoritealbums/{id}";
            public const string Delete = Root + "/userfavoritealbums/{id}";
        }

        public static class UserFavoriteSongs
        {
            public const string Create = Root + "/userfavoritesongs";
            public const string GetById = Root + "/userfavoritesongs/{id}";
            public const string GetAll = Root + "/userfavoritesongsbyuser/{id}";
            public const string Delete = Root + "/userfavoritesongs/{id}";
        }

        public static class UserFriends
        {
            public const string Create = Root + "/userfriends";
            public const string AcceptRequest = Root + "/userfriends/acceptrequest";
            public const string Delete = Root + "/userfriends/{id}";
            public const string GetById = Root + "/userfriends/{id}";
            public const string GetAll = Root + "/userfriendsbyuserId/{userId}";
        }

        public static class Posts
        {
            public const string Create = Root + "/posts";
            public const string Update = Root + "/posts";
            public const string Delete = Root + "/posts/{id}";
            public const string GetById = Root + "/posts/{id}";
            public const string GetAll = Root + "/posts";
            public const string GetUserPosts = Root + "/userposts/{userId}/{page}/{pageSize}";
        }

        public static class ArtistRatings
        {
            public const string Create = Root + "/artistratings";
            public const string Update = Root + "/artistratings";
            public const string Delete = Root + "/artistratings/{id}";
            public const string GetById = Root + "/artistratings/{id}";
            public const string GetAll = Root + "/listartistratings/{id}";
        }

        public static class AlbumRatings
        {
            public const string Create = Root + "/albumratings";
            public const string Update = Root + "/albumratings";
            public const string Delete = Root + "/albumratings/{id}";
            public const string GetById = Root + "/albumratings/{id}";
            public const string GetAll = Root + "/listalbumratings/{id}";
            public const string GetUserRating = Root + "/albumratings/{id}/user/{userId}";
        }

        public static class SongRatings
        {
            public const string Create = Root + "/songratings";
            public const string Update = Root + "/songratings";
            public const string Delete = Root + "/songratings/{id}";
            public const string GetById = Root + "/songratings/{id}";
            public const string GetAll = Root + "/listsongratings/{id}";
            public const string GetUserRating = Root + "/songratings/{id}/user/{userId}";

        }

        public static class Chats
        {
            public const string Create = Root + "/chats";
            public const string Update = Root + "/chats";
            public const string Delete = Root + "/chats/{id}";
            public const string GetUserChats = Root + "/chats/user/{id}";
        }

        public static class Messages
        {
            public const string Create = Root + "/messages";
            public const string GetPagedByChatId = Root + "/messages/{id}/{page}/{size}";
            public const string GetMessageById = Root + "/messages/{id}";
        }
    }
}
