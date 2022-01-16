using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumFileUpdateDto
    {
        public int AlbumId { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
