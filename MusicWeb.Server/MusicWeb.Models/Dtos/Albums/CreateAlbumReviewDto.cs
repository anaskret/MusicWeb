using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums.Create
{
    public class CreateAlbumReviewDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int AlbumId { get; set; }
        public string UserId { get; set; }
        public int RatingId { get; set; }
    }
}
