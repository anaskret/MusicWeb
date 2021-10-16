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
            public const string GetAll = Root + "/artists";
            public const string Update = Root + "/artists";
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
        }

        public static class UserFavoriteArtists
        {
            public const string Create = Root + "/userfavoriteartists";
            public const string GetAll = Root + "/userfavoriteartists";
            public const string GetById = Root + "/userfavoriteartists/{id}";
            public const string Delete = Root + "/userfavoriteartists/{id}";
        }

        public static class UserFavoriteAlbums
        {
            public const string Create = Root + "/userfavoritealbums";
            public const string GetAll = Root + "/userfavoritealbums";
            public const string GetById = Root + "/userfavoritealbums/{id}";
            public const string Delete = Root + "/userfavoritealbums/{id}";
        }

        public static class UserFavoriteSongs
        {
            public const string Create = Root + "/userfavoritesongs";
            public const string GetById = Root + "/userfavoritesongs/{id}";
            public const string GetAll = Root + "/userfavoritesongs";
            public const string Delete = Root + "/userfavoritesongs/{id}";
        }

        public static class UserFriends
        {
            public const string Create = Root + "/userfriends";
            public const string Update = Root + "/userfriends";
            public const string Delete = Root + "/userfriends/{id}";
            public const string GetById = Root + "/userfriends/{id}";
            public const string GetAll = Root + "/userfriends";
        }

        public static class Posts
        {
            public const string Create = Root + "/posts";
            public const string Update = Root + "/posts";
            public const string Delete = Root + "/posts/{id}";
            public const string GetById = Root + "/posts/{id}";
            public const string GetAll = Root + "/posts";
            public const string GetUserPosts = Root + "/userposts/{userId}";
        }
    }
}
