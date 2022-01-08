using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Models.Dtos.Chats.Base
{
    public class BaseMessageDto
    {
        public int ChatId { get; set; }
        public string SenderId { get; set; }

        public string Text { get; set; }
        public byte[] ImageBytes { get; set; }
    }
}
