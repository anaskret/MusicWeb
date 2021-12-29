using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class CreatePostCommentDto
    {
        public int PostId { get; set; }
        public string UserId { get; set; }
        public string Text { get; set; }
    }
}
