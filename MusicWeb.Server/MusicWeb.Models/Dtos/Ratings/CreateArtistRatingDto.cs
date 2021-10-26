using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Ratings
{
    public class CreateArtistRatingDto
    {
        [Range(1, 5, ErrorMessage = "Rating has to have value between 1 and 5")]
        public int Rating { get; set; }

        public int ArtistId { get; set; }
        public string UserId { get; set; }
    }
}
