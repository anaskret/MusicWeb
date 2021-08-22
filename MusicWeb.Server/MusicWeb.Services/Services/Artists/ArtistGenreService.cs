using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Artists;
using MusicWeb.Services.Interfaces.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Services.Artists
{
    public class ArtistGenreService : IArtistGenreService
    {
        private readonly IArtistGenreRepository _artistGenreRepository;

        public ArtistGenreService(IArtistGenreRepository artistGenreRepository)
        {
            _artistGenreRepository = artistGenreRepository;
        }

        public async Task AddAsync(ArtistGenre entity)
        {
            await _artistGenreRepository.AddAsync(entity);
        }
    }
}
