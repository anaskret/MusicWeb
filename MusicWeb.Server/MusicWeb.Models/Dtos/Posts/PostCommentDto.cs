using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class PostCommentDto : CreatePostCommentDto
    {
        public int Id { get; set; }
        public DateTime PostDate { get; set; }
    }
}
