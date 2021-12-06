using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Ratings
{
    public class SongRatingDto: CreateSongRatingDto
    {
        public int Id { get; set; }       
    }
}
