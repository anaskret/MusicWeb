using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
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
        Task<List<SongReviewDto>> GetAllAsync();
        Task AddAsync(SongReview entity);
        Task UpdateAsync(SongReview entity);
        Task DeleteAsync(int id);
        Task<SongReviewFullDataDto> GetSongReviewFullDataByIdAsync(int id);
    }
}
