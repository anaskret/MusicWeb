using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class CreatorSongModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Length has to be larger than 0")]
        public double Length { get; set; }

        public string ImagePath { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Position on album has to be larger than 0")]
        public int PositionOnAlbum { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Text { get; set; }

        public bool IsConfirmed { get; set; } = true;

        public int AlbumId { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Composer is required")]
        public int ComposerId { get; set; }

        public int ListIndex { get; set; }
    }
}
