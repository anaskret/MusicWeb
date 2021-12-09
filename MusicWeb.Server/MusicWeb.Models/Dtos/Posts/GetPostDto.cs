using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class GetPostDto : PostDto
    {
        public string UserName { get; set; }
        public int ArtistId { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public string Image { get; set; }
        public string AlbumImage { get; set; }
        public bool IsLiked { get; set; }
        public int TotalLikes { get; set; }
    }
}
