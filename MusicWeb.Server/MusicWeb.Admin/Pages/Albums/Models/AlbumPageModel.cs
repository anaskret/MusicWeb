using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class AlbumPageModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ArtistName { get; set; }
        public string AlbumGenreName { get; set; }
        public double Duration { get; set; }
        public string Description { get; set; }
        public bool IsConfirmed { get; set; }

        public List<SongPageModel> SongList { get; set; }

        public AlbumPageModel()
        {
            SongList = new List<SongPageModel>();
        }
    }
}
