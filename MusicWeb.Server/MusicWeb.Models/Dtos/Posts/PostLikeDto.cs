using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class PostLikeDto
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
    }
}
