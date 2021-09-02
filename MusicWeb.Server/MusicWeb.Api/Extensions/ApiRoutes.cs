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
            public const string GetAll = Root + "/artistdata";
            public const string Create = Root + "/artists";
        }

        public static class ArtistComments
        {
            public const string Create = Root + "/artistcomments";
        }

        public static class BandMembers
        {
            public const string Create = Root + "/bandmembers";
        }

        public static class Albums
        {
            public const string Create = Root + "/albums";
        }

        public static class Genres
        {
            public const string Create = Root + "/genres";
        }

        public static class ArtistGenres
        {
            public const string Create = Root + "/artistgenres";
        }

        public static class Origins
        {
            public const string CreateCountry = Root + "/origins/country";
            public const string CreateState = Root + "/origins/state";
            public const string CreateCity = Root + "/origins/city";
        }

        public static class Identity
        {
            public const string Register = Root + "/register";
            public const string Login = Root + "/login";
        }
    }
}
