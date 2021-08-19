using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Origin : BaseEntity
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public ICollection<Artist> Artists{ get; set; }
    }
}
