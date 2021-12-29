using MusicWeb.Admin.Pages.Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Factories.Interfaces
{
    public interface IAlbumFactory
    {
        Task<List<AlbumPageModel>> PrepareAlbums();
        Task PrepareSongs(AlbumPageModel model);
    }
}
