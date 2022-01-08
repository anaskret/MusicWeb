using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Songs
{
    public interface ISongReviewService
    {
        Task<SongReview> GetByIdAsync(int id);
        Task<List<SongReviewFullDataDto>> GetAllAsync();
        Task AddAsync(SongReview entity);
        Task UpdateAsync(SongReview entity);
        Task DeleteAsync(int id);
        Task<SongReviewFullDataDto> GetSongReviewFullDataByIdAsync(int id);
        Task<List<SongReviewRating>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15);
    }
}
