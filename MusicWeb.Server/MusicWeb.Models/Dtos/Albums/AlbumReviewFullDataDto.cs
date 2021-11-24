using MusicWeb.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Albums
{
    public class AlbumReviewFullDataDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public int SongId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public AlbumDto Album { get; set; }
        public AlbumReviewFullDataDto()
        {
            var User = new ApplicationUser();
            var Album = new AlbumDto();
        }
    }
}
