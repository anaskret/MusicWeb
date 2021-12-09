using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Posts
{
    public class PostComment : BaseEntity
    {
        public string UserId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime PostDate { get; set; }

        public virtual Post Post { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
