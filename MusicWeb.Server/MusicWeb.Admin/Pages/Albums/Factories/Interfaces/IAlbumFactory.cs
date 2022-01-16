using MusicWeb.Admin.Pages.Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Factories.Interfaces
{
    public interface IAlbumFactory
    {
        Task PrepareCreator(List<ArtistSelectModel> artists, List<GenreSelectModel> genres);
        Task<List<AlbumPageModel>> PrepareAlbums(int filter);
        Task PrepareSongs(AlbumPageModel model);
    }
}
