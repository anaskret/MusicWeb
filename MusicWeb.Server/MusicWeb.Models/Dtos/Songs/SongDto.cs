using MusicWeb.Models.Dtos.Songs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class SongDto: BaseSongDto
    {
        public int Id { get; set; }
    }
}
