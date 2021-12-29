using FluentAssertions;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MusicWeb.Api;
using MusicWeb.Api.Extensions.DependencyResolver;
using MusicWeb.DataAccess.Data;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Enums;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicWeb.Tests.Artists
{
    public class ArtistServiceTests : InMemoryDatabase
    {
       /* readonly IServiceProvider _serviceProvider =
        Program.CreateHostBuilder(new string[] { }).Build().Services;*/

        public ArtistServiceTests()
        {
            /*var webHost = WebHost.CreateDefaultBuilder()
                    .UseStartup<Startup>()
                    .Build();
            _serviceProvider = new DependencyResolverHelper(webHost);*/

        }

        [Fact]
        public async Task BandMemberBandNotFound_ThrowsArgumentException()
        {
            /*var countryId = await CreateCountry();

            var bandMember = new Artist
            {
                Name = "test",
                EstablishmentDate = DateTime.Now,
                Bio = "test",
                Type = ArtistType.BandMember,
                CountryId = countryId,
                BandId = 1
            };

            var artistService = _serviceProvider.GetRequiredService<IArtistService>();

            Func<Task> act = async () => await artistService.AddAsync(bandMember, new byte[0]);

            await act.Should().ThrowAsync<ArgumentException>().WithMessage("Incorrect BandId");*/
        }

        private async Task<int> CreateCountry()
        {
            return 0;
           /* var country = new Country
            {
                Name = "country"
            };

            var _countryService = _serviceProvider.GetRequiredService<IOriginService>();
            await _countryService.AddCountryAsync(country);

            return country.Id;*/
        }
    }
}
