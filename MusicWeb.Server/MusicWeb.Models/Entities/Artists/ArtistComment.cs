using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class ArtistComment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime PostDate { get; set; }

        public int ArtistId { get; set; }
        public string UserId { get; set; }
        public virtual Artist Artist{ get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
