using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Entities.Posts;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class UserObservedArtist : BaseEntity
    {
        public DateTime ObservedDate { get; set; }

        public string UserId { get; set; }
        public int ArtistId { get; set; }
        public virtual Artist Artist{ get; set; }
        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
