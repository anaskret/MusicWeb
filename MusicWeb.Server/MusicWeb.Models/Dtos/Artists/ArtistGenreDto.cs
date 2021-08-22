using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Artists
{
    public class ArtistGenreDto
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public int GenreId { get; set; }
        public string GenreName { get; set; }
    }
}
