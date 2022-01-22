using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using MusicWeb.Repositories.Interfaces.Albums;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Repositories.Interfaces.Base;
using MusicWeb.Repositories.Interfaces.Chats;
using MusicWeb.Repositories.Interfaces.Genres;
using MusicWeb.Repositories.Interfaces.Identity;
using MusicWeb.Repositories.Interfaces.Origins;
using MusicWeb.Repositories.Interfaces.Posts;
using MusicWeb.Repositories.Interfaces.Ratings;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Repositories.Repositories.Albums;
using MusicWeb.Repositories.Repositories.Artists;
using MusicWeb.Repositories.Repositories.Base;
using MusicWeb.Repositories.Repositories.Chats;
using MusicWeb.Repositories.Repositories.Genres;
using MusicWeb.Repositories.Repositories.Identity;
using MusicWeb.Repositories.Repositories.Origins;
using MusicWeb.Repositories.Repositories.Posts;
using MusicWeb.Repositories.Repositories.Ratings;
using MusicWeb.Repositories.Repositories.Songs;
using MusicWeb.Repositories.Repositories.Users;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.Albums;
using MusicWeb.Services.Interfaces.ApiIntegration;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Chats;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Identity;
using MusicWeb.Services.Interfaces.Origins;
using MusicWeb.Services.Interfaces.Posts;
using MusicWeb.Services.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Roles;
using MusicWeb.Services.Interfaces.Songs;
using MusicWeb.Services.Interfaces.Users;
using MusicWeb.Services.Services.Albums;
using MusicWeb.Services.Services.ApiIntegration;
using MusicWeb.Services.Services.Artists;
using MusicWeb.Services.Services.Chats;
using MusicWeb.Services.Services.Emails;
using MusicWeb.Services.Services.Files;
using MusicWeb.Services.Services.Genres;
using MusicWeb.Services.Services.Identity;
using MusicWeb.Services.Services.Origins;
using MusicWeb.Services.Services.Posts;
using MusicWeb.Services.Services.Ratings;
using MusicWeb.Services.Services.Roles;
using MusicWeb.Services.Services.Songs;
using MusicWeb.Services.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Configuration
{
    public class DependencyInstaller
    {
        public static void InstallDependencies(IServiceCollection services)
        {

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IAlbumReviewRepository, AlbumReviewRepository>();
            services.AddTransient<IArtistsOnTheAlbumRepository, ArtistsOnTheAlbumRepository>();

            services.AddTransient<IArtistRepository, ArtistRepository>();
            services.AddTransient<IArtistCommentRepository, ArtistCommentRepository>();
            services.AddTransient<IBandRepository, BandRepository>();

            services.AddTransient<ISongRepository, SongRepository>();

            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<ISongGuestArtistRepository, SongGuestArtistRepository>();
            services.AddTransient<ISongReviewRepository, SongReviewRepository>();

            services.AddTransient<IUserFavoriteArtistRepository, UserFavoriteArtistRepository>();
            services.AddTransient<IUserFavoriteArtistService, UserFavoriteArtistService>();

            services.AddTransient<IUserFavoriteAlbumRepository, UserFavoriteAlbumRepository>();
            services.AddTransient<IUserFavoriteAlbumService, UserFavoriteAlbumService>();

            services.AddTransient<IUserFavoriteSongRepository, UserFavoriteSongRepository>();
            services.AddTransient<IUserFavoriteSongService, UserFavoriteSongService>();

            services.AddTransient<IUserFriendRepository, UserFriendRepository>();
            services.AddTransient<IUserFriendService, UserFriendService>();

            services.AddTransient<IUserObservedArtistRepository, UserObservedArtistRepository>();
            services.AddTransient<IUserObservedArtistService, UserObservedArtistService>();

            services.AddTransient<IArtistCommentService, ArtistCommentService>();
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<IBandService, BandService>();

            services.AddTransient<IGenreService, GenreService>();

            services.AddTransient<IOriginService, OriginService>();

            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IAlbumReviewService, AlbumReviewService>();

            services.AddTransient<ISongService, SongService>();
            services.AddTransient<ISongReviewService, SongReviewService>();

            services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            services.AddTransient<IPostRepository, PostRepository>();
            services.AddTransient<IPostService, PostService>();
            services.AddTransient<IPostLikeRepository, PostLikeRepository>();
            services.AddTransient<IPostLikeService, PostLikeService>();
            services.AddTransient<IPostCommentRepository, PostCommentRepository>();
            services.AddTransient<IPostCommentService, PostCommentService>();

            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IArtistRatingRepository, ArtistRatingRepository>();
            services.AddTransient<IArtistRatingService, ArtistRatingService>();

            services.AddTransient<IAlbumRatingRepository, AlbumRatingRepository>();
            services.AddTransient<IAlbumRatingService, AlbumRatingService>();

            services.AddTransient<ISongRatingRepository, SongRatingRepository>();
            services.AddTransient<ISongRatingService, SongRatingService>();

            services.AddTransient<IRolesService, RolesService>();

            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();

            services.AddTransient<IApiIntegrationService, ApiIntegrationService>();
            services.AddTransient<IEmailSender, EmailService>();
        }
    }
}
