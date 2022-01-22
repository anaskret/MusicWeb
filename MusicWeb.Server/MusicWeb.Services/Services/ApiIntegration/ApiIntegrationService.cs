using Microsoft.Extensions.Configuration;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Origins;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Responses.ApiIntegration;
using MusicWeb.Services.Interfaces;
using MusicWeb.Services.Interfaces.ApiIntegration;
using MusicWeb.Services.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Genres;
using MusicWeb.Services.Interfaces.Origins;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.ApiIntegration
{
    public class ApiIntegrationService : IApiIntegrationService
    {
        private readonly IOriginService _originService;
        private readonly IArtistService _artistService;
        private readonly IGenreService _genreService;
        private readonly IAlbumService _albumService;
        private readonly ISongService _songService;
        private readonly IConfiguration _configuration;

        private readonly string _apiKey;

        public ApiIntegrationService(IOriginService originService,
                                     IArtistService artistService,
                                     IGenreService genreService,
                                     IAlbumService albumService,
                                     ISongService songService, 
                                     IConfiguration configuration)
        {
            _originService = originService;
            _artistService = artistService;
            _genreService = genreService;
            _albumService = albumService;
            _songService = songService;
            _configuration = configuration;

            _apiKey = _configuration.GetValue<string>("ApiKey");
        }

        public async Task IntegrateAsync()
        {
            await IntegrateCountriesAsync();
            Task.Run(async () => await IntegrateArtistsAsync());
        }

        private async Task IntegrateCountriesAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage 
            { 
                Method = HttpMethod.Get, 
                RequestUri = new Uri("https://restcountries.com/v3.1/all")
            };

            var response = await client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<List<SingleCountry>>(await response.Content.ReadAsStringAsync());
            var localCountries = await _originService.GetAllCountriesAsync();

            var newCountries = new List<Country>();
            foreach(var item in result)
            {
                if (!localCountries.Any(prp => string.Equals(prp.Code, item.cca3)))
                    newCountries.Add(new Country { Name = item.name.common, Code = item.cca3 });
            }

            if(!localCountries.Any(prp => string.Equals(prp.Code, "NotSet")))
                newCountries.Add(new Country { Code = "NotSet", Name = "Not set" });

            await _originService.AddCountriesRangeAsync(newCountries);
        }

        private async Task IntegrateArtistsAsync()
        {
            var client = new HttpClient();

            for (int i = 119240; i < 120000; i++)
            {
                try
                {
                    var request = new HttpRequestMessage
                    {
                        Method = HttpMethod.Get
                    };

                    string uri = $"https://www.theaudiodb.com/api/v1/json/{_apiKey}/artist.php?i={i}";
                    request.RequestUri = new Uri(uri);

                    var response = await client.SendAsync(request);
                    var root = JsonConvert.DeserializeObject<ArtistResponseRoot>(await response.Content.ReadAsStringAsync());

                    if (root == null)
                        continue;
                    var result = root.artists.FirstOrDefault();
                    if (await _artistService.DoesArtistExistsByNameAsync(result.strArtist))
                        continue;

                    var country = await _originService.GetCountryByCodeAsync("NotSet");

                    var artistEntity = new Artist()
                    {
                        Name = result.strArtist,
                        EstablishmentDate = result.intFormedYear != null && string.IsNullOrEmpty(result.intFormedYear) ? new DateTime(Convert.ToInt32(result.intFormedYear), 1, 1) : new DateTime(),
                        Bio = result.strBiographyEN ?? "",
                        Type = Convert.ToInt32(result.intMembers) > 1 ? ArtistType.Band : ArtistType.Individual,
                        CountryId = country.Id
                    };
                    await _artistService.AddAsync(artistEntity, Array.Empty<byte>());

                    await IntegrateArtistAlbumAsync(result.idArtist, artistEntity.Id);
                }
                catch(Exception ex)
                {

                }
            }
        }

        private async Task IntegrateArtistAlbumAsync(string artistId, int musicWebArtistId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };

            string uri = $"https://theaudiodb.com/api/v1/json/{_apiKey}/album.php?i={artistId}";
            request.RequestUri = new Uri(uri);

            var response = await client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<AlbumResponseRoot>(await response.Content.ReadAsStringAsync());

            foreach(var album in result.album)
            {
                var genre = await _genreService.GetByNameAsync(album.strGenre);
                if (genre == null)
                    genre = await _genreService.AddAsync(new Genre() { Name = album.strGenre });

                var albumEntity = new Album()
                {
                    ArtistId = musicWebArtistId,
                    Name = album.strAlbum,
                    AlbumGenreId = genre.Id,
                    Description = album.strDescriptionEN ?? "",
                    IsConfirmed = true,
                    ReleaseDate = album.intYearReleased != null && string.IsNullOrEmpty(album.intYearReleased) ? new DateTime(Convert.ToInt32(album.intYearReleased), 1, 1) : new DateTime()
                };

                await _albumService.AddAsync(albumEntity);
                await IntegrateAlbumSongsAsync(album.idAlbum, musicWebArtistId, albumEntity.Id, albumEntity.ReleaseDate);
            }
        }

        private async Task IntegrateAlbumSongsAsync(string albumId, int musicWebArtistId, int musicWebAlbumId, DateTime releaseDate)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get
            };

            string uri = $"https://theaudiodb.com/api/v1/json/{_apiKey}/track.php?m={albumId}";
            request.RequestUri = new Uri(uri);

            var response = await client.SendAsync(request);
            var result = JsonConvert.DeserializeObject<SongResponseRoot>(await response.Content.ReadAsStringAsync());

            var songEntityList = new List<Song>();
            foreach(var song in result.track)
            {
                var songEntity = new Song()
                {
                    AlbumId = musicWebAlbumId,
                    Name = song.strTrack,
                    Length = Convert.ToDouble(song.intDuration),
                    ReleaseDate = releaseDate,
                    ComposerId = musicWebArtistId
                };

                songEntityList.Add(songEntity);
            }
            await _songService.AddRangeAsync(songEntityList);
        }
    }
}
