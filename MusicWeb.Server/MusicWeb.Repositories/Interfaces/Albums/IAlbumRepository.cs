using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Repositories.Interfaces.Albums
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> GetFullAlbumDataByIdAsync(int id);
     //   Task<List<Album>> GetAllAsync();
    }
}
