using MusicWeb.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Chats
{
    public interface IChatService
    {
        Task<List<Chat>> GetChatsByUserId(string userId);
        Task<Chat> GetByUserIdsAsync(string userId, string user2Id);
        Task<Chat> GetByIdAsync(int id);
        Task AddChat(Chat entity);
        Task UpdateChat(Chat entity);
        Task DeleteChat(int id);
    }
}
