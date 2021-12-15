using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
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
    }
}
