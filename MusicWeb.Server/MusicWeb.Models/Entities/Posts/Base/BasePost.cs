using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Posts.Base
{
    public abstract class BasePost : BaseEntity
    {
        public virtual string Text { get; set; }
        public virtual DateTime CreateDate { get; set; }

        public virtual ICollection<PostLike> PostLikes { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
