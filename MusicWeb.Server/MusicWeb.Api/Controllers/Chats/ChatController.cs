using Microsoft.AspNetCore.Mvc;

namespace MusicWeb.Api.Controllers.Chats
{
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }
    }
}
