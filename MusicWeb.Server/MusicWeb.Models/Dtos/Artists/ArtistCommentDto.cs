using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Artists
{
    public class ArtistCommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public int ArtistId { get; set; }
        public string UserId { get; set; }
    }
}
