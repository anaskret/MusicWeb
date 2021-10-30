using MusicWeb.Models.Entities.Artists;
using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Origins
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public int StateId { get; set; }
        public virtual State State{ get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
