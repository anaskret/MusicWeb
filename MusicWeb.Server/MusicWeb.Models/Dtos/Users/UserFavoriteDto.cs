using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UserFavoriteDto
    {
        public DateTime FavoriteDate { get; set; }

        public string UserId { get; set; }
        public string Name { get; set; }
        public int FavoriteId { get; set; }
    }
}
