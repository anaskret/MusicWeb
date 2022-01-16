using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class SongFileUpdateDto
    {
        public int SongId { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
