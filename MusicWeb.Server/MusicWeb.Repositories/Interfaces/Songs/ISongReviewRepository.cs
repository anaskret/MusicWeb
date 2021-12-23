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
    public interface ISongReviewRepository : IRepository<SongReview>
    {
        Task<SongReview> GetSongReviewFullDataByIdAsync(int id);
        Task<List<SongReviewRating>> GetSongsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15);

    }
}
