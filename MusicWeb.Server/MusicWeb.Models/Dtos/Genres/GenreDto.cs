using MusicWeb.Models.Dtos.Genres.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Genres
{
    public class GenreDto : CreateGenreDto
    {
        public int Id { get; set; }
    }
}
