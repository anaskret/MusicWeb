using MusicWeb.Models.Dtos.Songs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class CreateSongDto: BaseSongDto
    {
        public byte[] ImageBytes { get; set; }
    }
}
