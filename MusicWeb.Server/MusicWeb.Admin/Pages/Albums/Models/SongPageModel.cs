using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class SongPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Length { get; set; }
        public int AlbumId { get; set; }
    }
}
