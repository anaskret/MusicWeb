using Microsoft.AspNetCore.Mvc;
using MusicWeb.Services.Interfaces.Chats;

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
