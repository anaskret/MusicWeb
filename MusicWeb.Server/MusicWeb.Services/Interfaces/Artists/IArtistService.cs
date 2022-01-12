using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
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
        Task<IList<Artist>> GetAllAsync();
        Task<IList<Artist>> GetAllBandsAsync();
        Task<Artist> GetByIdAsync(int id);
        Task<List<ArtistRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
        Task<IPagedList<Artist>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue);
       Task AddAsync(Artist entity, byte[] imageBytes);
        Task AddArtistAsync(ArtistWithUserModel model);
        Task UpdateAsync(Artist entity);
        Task UpdateArtistAsync(Artist entity, byte[] imageBytes);
        Task<string> UpdateImageAsync(ArtistFileUpdateDto dto);
        Task DeleteAsync(int id);
        Task<ArtistRatingAverage> GetArtistRatingAverage(int id);
    }
}
