using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UserImageDto
    {
        public string UserId { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ImagePath { get; set; }
    }
}
