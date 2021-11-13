using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicWeb.Repositories.Interfaces.Chats;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MusicWeb.Services.Services.Chats
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        public async Task AddChat(Chat entity)
        {
            var doesExist = await GetByUserIdsAsync(entity.UserId, entity.FriendId);
            if (doesExist != null)
                throw new ArgumentException("Chat already exists!");

            await _chatRepository.AddAsync(entity);
        }

        public async Task DeleteChat(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null)
                throw new ArgumentException("Chat with this id doesn't exist");

            await _chatRepository.DeleteAsync(entity);
        }

        public async Task<Chat> GetByUserIdsAsync(string userId, string user2Id)
        {
            return await _chatRepository.GetSingleAsync(prp => string.Equals(prp.UserId, userId) && string.Equals(prp.FriendId, user2Id) || string.Equals(prp.FriendId, userId) && string.Equals(prp.UserId, user2Id));
        }

        public async Task<Chat> GetByIdAsync(int id)
        {
            return await _chatRepository.GetByIdAsync(id);
        }

        public async Task<List<Chat>> GetChatsByUserId(string userId)
        {
            var ilistEntites = await _chatRepository.GetAllAsync(obj => obj.Where(prp => string.Equals(prp.UserId, userId) 
                                                                                      || string.Equals(prp.FriendId, userId))
                                                                           .Include(prp => prp.User)
                                                                           .Include(prp => prp.Friend));
            return ilistEntites.ToList();
        }

        public async Task UpdateChat(Chat entity)
        {
            var doesExist = await GetByIdAsync(entity.Id);
            if (doesExist == null)
                throw new ArgumentException("Chat with this id doesn't exist");

            await _chatRepository.UpdateAsync(entity);
        }
    }
}
