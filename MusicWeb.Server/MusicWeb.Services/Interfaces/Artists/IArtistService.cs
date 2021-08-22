using MusicWeb.Models.Entities;
using MusicWeb.Models.Models.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Artists
{
    public interface IArtistService
    {
        Task AddAsync(Artist entity);
        Task<ArtistFullInfoDto> GetFullArtistInfoByIdAsync(int id);
    }
}
