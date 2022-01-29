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
        Task<List<Song>> GetAllForArtist(int artistId);
        Task<List<Song>> GetAllAsync();
        Task<SongFullDataDto> GetSongFullDataByIdAsync(int id);
        Task<List<TopSongsWithRating>> GetTopSongsWithRatingAsync(int artistId);
        Task AddAsync(Song entity);
        Task AddRangeAsync(List<Song> entities);
        Task UpdateAsync(Song entity);
        Task DeleteAsync(int id);
        Task DeleteRangeAsync(List<Song> entities);
        Task<List<Song>> GetSongsByAlbumIdAsync(int albumId);
        Task<SongRatingAverage> GetSongRatingAverage(int id);
        Task<List<SongRatingAverage>> GetPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
        Task<IPagedList<Song>> GetIPagedAsync(string searchString, int pageNum = 0, int pageSize = int.MaxValue);
        Task UpdateImageAsync(List<SongFileUpdateDto> dtoList);
        Task UploadAdminSongsImagesAsync(List<AdminSongCreateDto> dtoList, int albumId);
        Task<List<SongRatingAverage>> GetPagedRankingAsync(RankSortType sortType, int pageNum = 0, int pageSize = 5);

    }
}
