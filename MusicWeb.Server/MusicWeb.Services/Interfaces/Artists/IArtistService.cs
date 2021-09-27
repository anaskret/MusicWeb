using MusicWeb.Models.Dtos.Artists;
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
        Task<ArtistFullInfoDto> GetFullArtistInfoByIdAsync(int id);
        Task<List<ArtistDto>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task AddAsync(Artist entity);
        Task UpdateAsync(Artist entity);
        Task DeleteAsync(int id);
    }
}
