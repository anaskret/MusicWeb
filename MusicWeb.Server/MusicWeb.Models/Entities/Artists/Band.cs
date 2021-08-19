using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities
{
    public class Band : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists{ get; set; }
    }
}
