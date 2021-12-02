﻿using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicWeb.Repositories.Interfaces.Chats;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using MusicWeb.Services.Interfaces.Hubs;
using MusicWeb.Services.Hubs;

namespace MusicWeb.Services.Services.Chats
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatService _chatService;
        private readonly IHubContext<MessageHub, IMessageHub> _messageHub;

        public MessageService(IMessageRepository messageRepository,
            IChatService chatService, 
            IHubContext<MessageHub, IMessageHub> messageHub)
        {
            _messageRepository = messageRepository;
            _chatService = chatService;
            _messageHub = messageHub;
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task<List<Message>> GetMessagesByChatIdAsync(int chatId, int page = 0, int pageSize = int.MaxValue)
        {
            var entities = await _messageRepository.GetAllAsync(obj => obj.Where(prp => prp.Id == chatId)
                                                                          .Include(prp => prp.Sender)
                                                                          .Skip(page * pageSize)
                                                                          .Take(pageSize)
                                                                          .OrderByDescending(prp => prp.SendDate));

            return entities.ToList();
        }

        public async Task SendMessageAsync(Message entity)
        {
            var chatEntity = await _chatService.GetByIdAsync(entity.ChatId);
            if (chatEntity == null)
                throw new ArgumentException("Chat doesn't exist!");

            entity.SendDate = DateTime.Now;
            await _messageRepository.AddAsync(entity);

            string friendId;
            if (!string.Equals(chatEntity.UserId, entity.SenderId))
                friendId = chatEntity.UserId;
            else
                friendId = chatEntity.FriendId;

            await _messageHub.Clients.Group(friendId).SendMessage(friendId, chatEntity.Id);
        }
    }
}