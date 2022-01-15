using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class CreatorAlbumModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; }
        public string ImagePath { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Artist is required")]
        public int ArtistId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Genre is required")]
        public int AlbumGenreId { get; set; }

        public double Duration { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<CreatorSongModel> Songs { get; set; }

        public CreatorAlbumModel()
        {
            Songs = new List<CreatorSongModel>();
        }
    }
}
