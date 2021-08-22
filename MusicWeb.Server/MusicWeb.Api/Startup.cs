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
using MusicWeb.Repositories.Interfaces.Origins;
using MusicWeb.Repositories.Interfaces.Songs;
using MusicWeb.Repositories.Interfaces.Users;
using MusicWeb.Repositories.Repositories.Albums;
using MusicWeb.Repositories.Repositories.Artists;
using MusicWeb.Repositories.Repositories.Base;
using MusicWeb.Repositories.Repositories.Chats;
using MusicWeb.Repositories.Repositories.Genres;
using MusicWeb.Repositories.Repositories.Origins;
using MusicWeb.Repositories.Repositories.Songs;
using MusicWeb.Repositories.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MusicWeb.Api", Version = "v1" });
            });

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
            services.AddTransient<IArtistGenreRepository, ArtistGenreRepository>();
            services.AddTransient<IBandRepository, BandRepository>();

            services.AddTransient<IChatRepository, ChatRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddTransient<IGenreRepository, GenreRepository>();

            services.AddTransient<IOriginRepository, OriginRepository>();

            services.AddTransient<ISongRepository, SongRepository>();
            services.AddTransient<ISongGuestArtistRepository, SongGuestArtistRepository>();
            services.AddTransient<ISongReviewRepository, SongReviewRepository>();

            services.AddTransient<IUserFavoriteAlbumRepository, UserFavoriteAlbumRepository>();
            services.AddTransient<IUserFavoriteArtistRepository, UserFavoriteArtistRepository>();
            services.AddTransient<IUserFavoriteSongRepository, UserFavoriteSongRepository>();
            services.AddTransient<IUserFriendRepository, UserFriendRepository>();
            services.AddTransient<IUserObservedArtistRepository, UserObservedArtistRepository>();
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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
