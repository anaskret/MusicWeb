using ExpressiveAnnotations.Attributes;
using MusicWeb.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Artists
{
    public class ArtistPageRequest
    {
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Page Number has to be larger or equal 0")]
        public int PageNum { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Page Size has to be larger than 0")]
        public int PageSize { get; set; }
        
        public string SearchString { get; set; }
        [Required]
        [AssertThat("CreateDateStart < CreateDateEnd", ErrorMessage = "CreateDateStart has to be smaller than CreateDateEnd")]
        public DateTime CreateDateStart { get; set; } = DateTime.MinValue;
        [Required]
        public DateTime CreateDateEnd { get; set; } = DateTime.MaxValue;
        [Required]
        public SortType SortType{ get; set; }
    }
}
