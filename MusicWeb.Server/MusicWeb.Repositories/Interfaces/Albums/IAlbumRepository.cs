using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Albums
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> GetFullAlbumDataByIdAsync(int id);
        Task<AlbumRatingAverage> GetAlbumAverageRating(int id);
        Task<List<AlbumRatingAverage>> GetAlbumsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
        Task<List<AlbumRatingAverage>> GetAlbumRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 10);
    }
}
