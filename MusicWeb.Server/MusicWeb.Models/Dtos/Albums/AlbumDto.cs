using MusicWeb.Models.Dtos.Albums.Base;
using MusicWeb.Models.Dtos.Albums.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumDto : BaseAlbumDto
    {
        public int Id { get; set; }
        
        public string UserId { get; set; }
        public int Rating { get; set; }

    }
}
