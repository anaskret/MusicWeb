using MusicWeb.Models.Dtos.Albums;
using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces
{
    public interface IAlbumService
    {
        Task<Album> GetByIdAsync(int id);
        Task<List<AlbumDto>> GetAllAsync();
        Task<AlbumFullDataDto> GetFullAlbumDataByIdAsync(int id);
        Task AddAsync(Album entity);
        Task UpdateAsync(Album entity);
        Task DeleteAsync(int id);
    }
}
