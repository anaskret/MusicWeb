using MusicWeb.Models.Entities.Base;
using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Ratings
{
    public abstract class BaseRating : BaseEntity
    {
        public virtual int Rating { get; set; }
        public virtual string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
