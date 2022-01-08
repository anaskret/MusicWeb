using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Chats
{
    public interface IMessageService
    {
        Task SendMessageAsync(Message entity, byte[] imageBytes);
        Task<List<Message>> GetMessagesByChatIdAsync(int chatId, int page = 0, int pageSize = int.MaxValue);
        Task<Message> GetByIdAsync(int id);
    }
}
