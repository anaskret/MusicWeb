using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Songs
{
    public class SongReviewFullDataDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int SongId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public SongDto Song { get; set; }
        public string AlbumName { get; set; }
        public string ArtistName { get; set; }
        public SongReviewFullDataDto()
        {
            var Songs = new SongDto();
        }
    }
}
