using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Origins
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
