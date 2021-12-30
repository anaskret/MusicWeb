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
    public class UserFriend : BaseEntity
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string CreatedByUserId { get; set; }

        public bool IsAccepted { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationUser Friend { get; set; }
    }
}
