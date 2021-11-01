using MusicWeb.Admin.Models;
using MusicWeb.Admin.Pages.Artists.Models;
using MusicWeb.Models.Models.Artists;
using MusicWeb.Models.Models.Origins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Artists.Factories.Interfaces
{
    public interface IArtistModelFactory
    {
        Task PrepareCreator(List<CountryModel> countries, List<BandModel> bands);
        Task PrepareList(List<ArtistModel> list, PagerModel pager);
        Task<EditArtistModel> PrepareEdit(int id); 
    }
}
