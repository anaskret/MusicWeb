using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicWeb.Models.Dtos.Albums;

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
    }
}
