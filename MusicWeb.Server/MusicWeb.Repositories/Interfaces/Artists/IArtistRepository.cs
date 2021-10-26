using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Keyless;
using MusicWeb.Models.Enums;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Artists
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<Artist> GetFullArtistDataByIdAsync(int id);
        Task<List<ArtistRatingAverage>> GetArtistsPagedAsync(SortType sortType, DateTime startDate, DateTime endDate, int pageNum = 0, int pageSize = 15, string searchString = "");
    }
}
