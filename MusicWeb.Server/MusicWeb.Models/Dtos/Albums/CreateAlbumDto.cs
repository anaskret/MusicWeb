using MusicWeb.Models.Dtos.Albums.Base;
using MusicWeb.Models.Dtos.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums.Create
{
    public class CreateAlbumDto : BaseAlbumDto
    {
        public byte[] ImageBytes { get; set; }

    }
}
