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
        Task<List<SongDto>> GetAllAsync();
        Task<SongFullDataDto> GetSongFullDataByIdAsync(int id);
        Task AddAsync(Song entity);
        Task UpdateAsync(Song entity);
        Task DeleteAsync(int id);
        Task<SongRatingAverage> GetSongRatingAverage(int id);

    }
}
