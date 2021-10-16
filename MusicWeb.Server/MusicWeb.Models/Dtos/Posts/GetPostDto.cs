using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public string PosterName { get; set; }
        public string PosterId { get; set; }
        public string ArtistName { get; set; }
        public int? ArtistPosterId { get; set; }
        public string AlbumName { get; set; }
        public int? AlbumId { get; set; }
    }
}
