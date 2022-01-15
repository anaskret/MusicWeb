using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Entities.Ratings;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class AlbumReview : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int AlbumId { get; set; }
        public string UserId { get; set; }

        public virtual Album Album { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
