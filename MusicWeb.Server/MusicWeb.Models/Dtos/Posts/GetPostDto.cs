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
    }
}
