using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MusicWeb.Api.Middleware;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Identity;
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
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Identity;
using MusicWeb.Services.Interfaces.Origins;
using MusicWeb.Services.Interfaces.Posts;
using MusicWeb.Services.Interfaces.Ratings;
using MusicWeb.Services.Interfaces.Roles;
using MusicWeb.Services.Interfaces.Users;
using MusicWeb.Services.Services.Albums;
using MusicWeb.Services.Services.Artists;
using MusicWeb.Services.Services.Files;
using MusicWeb.Services.Services.Genres;
using MusicWeb.Services.Services.Identity;
using MusicWeb.Services.Services.Origins;
using MusicWeb.Services.Services.Posts;
using MusicWeb.Services.Services.Songs;
using MusicWeb.Services.Services.Ratings;
using MusicWeb.Services.Services.Roles;
using MusicWeb.Services.Services.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using MusicWeb.Services.Hubs;
using System.Threading.Tasks;
using MusicWeb.Services.Interfaces.Songs;
using MusicWeb.Services.Interfaces.Hubs;
using MusicWeb.Services.Interfaces.Chats;
using MusicWeb.Services.Services.Chats;

namespace MusicWeb.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("LocalConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                            .AddEntityFrameworkStores<AppDbContext>()
                            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"])),
                    RequireExpirationTime = false,
                };
            });

            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            var securityScheme = new OpenApiSecurityScheme
            {
                Name = "JWT Authentication",
                Description = "Enter JWT Bearer token **_only_**",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "bearer",
                BearerFormat = "JWT",
                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicWeb.Api", Version = "v1" });

                c.AddSecurityDefinition("Bearer", securityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                        Reference = new OpenApiReference
                            {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            services.AddSignalR();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalR();

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLogger>>();
            services.AddSingleton(typeof(ILogger), logger);

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

            services.AddTransient<IFileService, FileService>();

            services.AddTransient<IArtistRatingRepository, ArtistRatingRepository>();
            services.AddTransient<IArtistRatingService, ArtistRatingService>();

            services.AddTransient<IAlbumRatingRepository, AlbumRatingRepository>();
            services.AddTransient<IAlbumRatingService, AlbumRatingService>();

            services.AddTransient<IRolesService, RolesService>();

            services.AddTransient<IChatService, ChatService>();
            services.AddTransient<IMessageService, MessageService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MusicWeb.Api v1"));
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseCors(config => config
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
            
            app.UseStaticFiles();

            app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<FriendsHub>("/friendshub");
                endpoints.MapHub<UserHub>("/userhub");
            });
        }
    }
}
