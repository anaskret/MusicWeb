using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Users
{
    public class UserFriendDto : CreateUserFriendDto
    {
        public string FriendName { get; set; }
        public string CreatedByUserId { get; set; }
        public bool IsAccepted { get; set; }
    }
}
