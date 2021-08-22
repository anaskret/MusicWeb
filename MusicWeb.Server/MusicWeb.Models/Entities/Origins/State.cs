using MusicWeb.Models.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Entities.Origins
{
    public class State : BaseEntity
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public virtual Country Country{ get; set; }
        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
    }
}
