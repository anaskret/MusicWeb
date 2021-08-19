using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class UserFavoriteAlbum : BaseEntity
    {
        public DateTime FavoriteDate { get; set; }

        public string UserId { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
