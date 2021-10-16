using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class GetPostDto : PostDto
    {
        public string PosterName { get; set; }
        public string ArtistName { get; set; }
        public string AlbumName { get; set; }
    }
}
