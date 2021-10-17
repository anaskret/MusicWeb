using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists
{
    public class ArtistPageRequest
    {
        public int PageNum { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }
        public DateTime CreateDateStart { get; set; } = DateTime.MinValue;
        public DateTime CreateDateEnd { get; set; } = DateTime.MaxValue;
        public SortType SortType{ get; set; }
    }
}
