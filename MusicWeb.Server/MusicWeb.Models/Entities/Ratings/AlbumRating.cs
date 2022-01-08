using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Ratings
{
    public class AlbumRating : BaseRating
    {
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public int? ReviewId { get; set; }
        public virtual AlbumReview AlbumReview { get; set; }

    }
}
