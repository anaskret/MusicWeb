using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Genres
{
    public interface IGenreService
    {
        Task AddAsync(Genre entity);
    }
}
