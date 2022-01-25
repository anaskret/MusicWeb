using MusicWeb.Admin.Pages.Albums.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Factories.Interfaces
{
    public interface ISongFactory
    {
        Task<CreatorSongModel> PrepareEdit(int songId, List<ArtistSelectModel> composers);
    }
}
