using ExpressiveAnnotations.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Posts
{
    public class CreatePostDto
    {
        [Required(ErrorMessage = "Text is required")]
        public string Text { get; set; }

        [Required(ErrorMessage = "CreateDate is required")]
        public DateTime CreateDate { get; set; }

        [RequiredIf("ArtistPosterId == 0", ErrorMessage = "Post has to have a PosterId when ArtistPosterId isn't set")]
        public string PosterId { get; set; }

        [RequiredIf("PosterId.Length == 0", ErrorMessage = "Post has to have an ArtistPosterId when PosterId isn't set")]
        public int? ArtistPosterId { get; set; }

        [RequiredIf("ArtistPosterId > 0", ErrorMessage = "AlbumId is required when the ArtistPosterId is larger than 0")]
        public int? AlbumId { get; set; }
    }
}
