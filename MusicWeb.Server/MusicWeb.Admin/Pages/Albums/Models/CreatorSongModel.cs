using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Albums.Models
{
    public class CreatorSongModel : INotifyPropertyChanged
    {
        private string _name, _text, _imagePath;
        private DateTime _releaseDate = DateTime.Now;
        private double _length;
        private byte[] _imageBytes;
        private int _composerId, _positionOnAlbum;

        [Required(ErrorMessage = "Name is required")]
        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        [Required(ErrorMessage = "Release Date is required")]
        public DateTime ReleaseDate
        {
            get => _releaseDate;
            set
            {
                if (value != _releaseDate)
                {
                    _releaseDate = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ReleaseDate)));
                }
            }
        }

        [Range(double.Epsilon, int.MaxValue, ErrorMessage = "Length has to be larger than 0")]
        public double Length
        {
            get => _length;
            set
            {
                if (value != _length)
                {
                    _length = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Length)));
                }
            }
        }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                if (value != _imagePath)
                {
                    _imagePath = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImagePath)));
                }
            }
        }
        public byte[] ImageBytes
        {
            get => _imageBytes;
            set
            {
                if (value != _imageBytes)
                {
                    _imageBytes = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageBytes)));
                }
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Position on album has to be larger than 0")]
        public int PositionOnAlbum
        {
            get => _positionOnAlbum;
            set
            {
                if (value != _positionOnAlbum)
                {
                    _positionOnAlbum = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PositionOnAlbum)));
                }
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                if (value != _text)
                {
                    _text = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Text)));
                }
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "Composer is required")]
        public int ComposerId
        {
            get => _composerId;
            set
            {
                if (value != _composerId)
                {
                    _composerId = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ComposerId)));
                }
            }
        }

        public bool IsConfirmed { get; set; } = true;
        public int AlbumId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
