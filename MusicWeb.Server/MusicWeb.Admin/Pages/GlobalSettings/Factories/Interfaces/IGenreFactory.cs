using MusicWeb.Admin.Pages.GlobalSettings.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.GlobalSettings.Factories.Interfaces
{
    public interface IGenreFactory
    {
        Task PrepareList(List<GenrePageModel> list);
        Task<GenrePageModel> PrepareModel(int id);
    }
}
