using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Extensions.Pagination.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces
{
    public interface ISongService
    {
        Task<Song> GetByIdAsync(int id);
        Task<List<SongDto>> GetAllAsync();
        Task<SongFullDataDto> GetSongFullDataByIdAsync(int id);
        Task AddAsync(Song entity);
        Task UpdateAsync(Song entity);
        Task DeleteAsync(int id);
        Task<SongRatingAverage> GetSongRatingAverage(int id);
        Task<List<SongRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
        Task<IPagedList<Song>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue);


    }
}
