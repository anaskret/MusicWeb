using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Enums;
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
        Task<List<Artist>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
        Task AddAsync(Artist entity, byte[] imageBytes);
        Task UpdateAsync(Artist entity);
        Task UpdateImageAsync(ArtistFileUpdateDto dto);
        Task DeleteAsync(int id);
    }
}
