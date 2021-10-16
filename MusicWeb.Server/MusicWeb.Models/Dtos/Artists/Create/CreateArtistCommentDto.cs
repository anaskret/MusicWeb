using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists.Create
{
    public class CreateArtistCommentDto
    {
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public int ArtistId { get; set; }
        public string UserId { get; set; }
    }
}
