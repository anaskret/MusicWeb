using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Keyless
{
    public class UserAndArtistPost
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserName { get; set; }
        public string PosterId { get; set; }
        public int? ArtistId { get; set; }
        public string Artist { get; set; }
        public int? AlbumId { get; set; }
        public string Album { get; set; }
        public string Image { get; set; }
        public string AlbumImage { get; set; }
        public bool IsLiked { get; set; }
        public int TotalLikes { get; set; }
    }
}
