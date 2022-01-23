using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using MusicWeb.Models.Enums;
using MusicWeb.Models.Entities.Keyless;

namespace MusicWeb.Services.Interfaces.Albums
{
    public interface IAlbumReviewService
    {
        Task<AlbumReview> GetByIdAsync(int id);
        Task<List<AlbumReviewFullDataDto>> GetAllAsync();
        Task AddAsync(AlbumReview entity);
        Task UpdateAsync(AlbumReview entity);
        Task DeleteAsync(int id);
        Task<AlbumReviewFullDataDto> GetAlbumReviewFullDataByIdAsync(int id);
        Task<List<AlbumReviewRating>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15);
        Task<List<AlbumReviewRating>> GetAlbumReviewsPagedAsync(int albumId, int pageNum = 0, int pageSize = 15);
        Task<IPagedList<AlbumReview>> GetIPagedAsync(int pageNum = 0, int pageSize = int.MaxValue);
    }
}
