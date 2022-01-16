using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class CreatorAlbumModel : INotifyPropertyChanged
    {
        private List<CreatorSongModel> _songs;

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;
        public string ImagePath { get; set; }
        public byte[] ImageBytes { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Artist is required")]
        public int ArtistId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Genre is required")]
        public int AlbumGenreId { get; set; }

        public double Duration { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public List<CreatorSongModel> Songs
        {
            get => _songs;
            set
            {
                if (value != _songs)
                {
                    _songs = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Songs)));
                }
            }
        }

        public CreatorAlbumModel()
        {
            Songs = new List<CreatorSongModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
