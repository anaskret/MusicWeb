using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Keyless
{
    public class SongReviewRating
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int SongId { get; set; }
        public string UserId { get; set; }
        public int Rating { get; set; }
    }
}
