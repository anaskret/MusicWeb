using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string PosterId { get; set; }
        public int? ArtistPosterId { get; set; }
        public int? AlbumId { get; set; }
    }
}
