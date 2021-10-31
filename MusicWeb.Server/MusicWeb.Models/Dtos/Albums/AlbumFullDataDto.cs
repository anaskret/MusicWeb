using MusicWeb.Models.Dtos.Artists;
using MusicWeb.Models.Dtos.Genres;
using MusicWeb.Models.Dtos.Songs;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Entities.Artists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumFullDataDto
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int ArtistId { get; set; }
        public int AlbumGenreId { get; set; }
        public double duration { get; set; }
        public string description { get; set; }
        public Boolean isConfirmed { get; set; }
        public List<SongDto> Songs { get; set; }
        public List<AlbumReviewDto> AlbumReviews {get;set;}
        public ArtistDto Artist { get; set; }
        public GenreDto AlbumGenre { get; set; }
        public AlbumFullDataDto()
        {
            Songs = new List<SongDto>();
            AlbumReviews = new List<AlbumReviewDto>();
            Artist = new ArtistDto();
            AlbumGenre = new GenreDto();
        }
    }
}
