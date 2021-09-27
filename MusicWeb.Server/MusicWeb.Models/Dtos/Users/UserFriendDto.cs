using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UserFriendDto
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public string FriendName { get; set; }
    }
}
