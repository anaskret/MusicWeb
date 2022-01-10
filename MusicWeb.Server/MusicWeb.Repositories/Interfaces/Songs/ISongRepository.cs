using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Songs
{
    public interface ISongRepository : IRepository<Song>
    {
        Task<Song> GetSongFullDataByIdAsync(int id);
        Task<List<TopSongsWithRating>> GetTopSongsWithRatingsAsync(int artistId);
        Task<SongRatingAverage> GetSongAverageRating(int id);
        Task<List<SongRatingAverage>> GetSongsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");

    }
}
