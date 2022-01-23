using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MusicWeb.Models.Models.Identity
{
    public class LoginResponse
    {
        public string UserId { get; set; }
        public int LastOpenedChatId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
