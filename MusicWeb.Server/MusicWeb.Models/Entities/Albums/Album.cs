using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Album : BaseEntity
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }

        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

        public int AlbumGenreId { get; set; }
        public virtual Genre AlbumGenre { get; set; }

        public virtual ICollection<Song> Songs{ get; set; }
        public virtual ICollection<AlbumReview> AlbumReviews{ get; set; }
        public virtual ICollection<UserFavoriteAlbum> UserFavoriteAlbums{ get; set; }
        public virtual ICollection<ArtistsOnTheAlbum> ArtistsOnTheAlbums{ get; set; }
    }
}
