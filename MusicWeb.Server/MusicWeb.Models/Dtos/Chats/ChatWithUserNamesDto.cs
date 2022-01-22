using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Chats
{
    public class ChatWithUserNamesDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FriendName { get; set; }
        public string FullName { get; set; }
        public string FriendFullName { get; set; }
    }
}
