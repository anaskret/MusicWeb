using AutoMapper;
using MusicWeb.Admin.Pages.Albums.Models;
using MusicWeb.Admin.Pages.Artists.Models;
using MusicWeb.Admin.Pages.Settings.Models;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Identity;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Models.Models.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Extenstions.AutoMapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ApplicationUser, UserListModel>();
            CreateMap<ApplicationUser, UserModel>();
            CreateMap<ApplicationUser, EditUserModel>();
            CreateMap<EditUserModel, ApplicationUser>();

            CreateMap<Country, CountryModel>();

            CreateMap<Artist, BandModel>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<ArtistWithUserModel, Artist>();
            CreateMap<EditArtistModel, Artist>();
            CreateMap<Artist, EditArtistModel>();
            CreateMap<Artist, ArtistSelectModel>();

            CreateMap<Album, AlbumPageModel>()
                .ForMember(prp => prp.AlbumGenreName, obj => obj.MapFrom(src => src.AlbumGenre.Name))
                .ForMember(prp => prp.ArtistName, obj => obj.MapFrom(src => src.Artist.Name));
            CreateMap<Song, SongPageModel>();
        }
    }
}
