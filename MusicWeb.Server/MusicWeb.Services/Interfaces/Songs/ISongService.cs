using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Keyless;
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
        Task<List<Song>> GetAllAsync();
        Task<SongFullDataDto> GetSongFullDataByIdAsync(int id);
        Task<List<TopSongsWithRating>> GetTopSongsWithRatingAsync(int artistId);
        Task AddAsync(Song entity);
        Task UpdateAsync(Song entity);
        Task DeleteAsync(int id);
        Task<List<Song>> GetSongsByAlbumIdAsync(int albumId);
    }
}
