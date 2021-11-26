using MusicWeb.Models.Dtos.Chats.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Chats
{
    public class MessageDto : BaseMessageDto
    {
        public DateTime SendDate { get; set; }
        public string SenderName { get; set; }
    }
}
