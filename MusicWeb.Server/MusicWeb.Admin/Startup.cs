using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicWeb.Admin.Areas.Identity;
using MusicWeb.Admin.Middleware;
using MusicWeb.Admin.Pages.Albums.Factories;
using MusicWeb.Admin.Pages.Albums.Factories.Interfaces;
using MusicWeb.Admin.Pages.Artists.Factories;
using MusicWeb.Admin.Pages.Artists.Factories.Interfaces;
using MusicWeb.Admin.Pages.Settings.Factories;
using MusicWeb.Admin.Pages.Settings.Factories.Interfaces;
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
using MusicWeb.Services.Configuration;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.ApiIntegration;
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
using MusicWeb.Services.Services.ApiIntegration;
using MusicWeb.Services.Services.Artists;
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
using System.Threading.Tasks;

namespace MusicWeb.Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("LocalConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<ApplicationLogger>>();
            services.AddSingleton(typeof(ILogger), logger);

            DependencyInstaller.InstallDependencies(services);

            services.AddScoped<IUserModelFactory, UserModelFactory>();
            services.AddTransient<IArtistModelFactory, ArtistModelFactory>();
            services.AddTransient<IAlbumFactory, AlbumFactory>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<AppDbContext>();
            var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
            var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

            if (!context.Database.EnsureCreated())
            {
                var adminUser = userManager.FindByNameAsync("admin").Result;

                if (adminUser != null)
                    return;

                var user = new ApplicationUser
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    UserName = "admin",
                    Email = "admin@wp.pl",
                    LockoutEnabled = false,
                    Type = MusicWeb.Models.Enums.UserType.Admin
                };

                var result = userManager.CreateAsync(user, "Admin123").Result;
                if (result.Succeeded)
                {
                    result = userManager.AddToRoleAsync(user, "Admin").Result;

                    user.LockoutEnabled = false;
                    result = userManager.UpdateAsync(user).Result;
                }
            }
        }
    }
}
