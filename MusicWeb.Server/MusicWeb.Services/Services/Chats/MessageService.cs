using MusicWeb.Models.Entities;
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
using Microsoft.AspNetCore.Identity;
using MusicWeb.Models.Identity;
using MusicWeb.Services.Interfaces.Files;
using System.IO;
using MusicWeb.Models.Constants;

namespace MusicWeb.Services.Services.Chats
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IChatService _chatService;
        private readonly IHubContext<MessageHub, IMessageHub> _messageHub;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IFileService _fileService;

        public MessageService(IMessageRepository messageRepository,
            IChatService chatService,
            IHubContext<MessageHub, IMessageHub> messageHub,
            UserManager<ApplicationUser> userManager, 
            IFileService fileService)
        {
            _messageRepository = messageRepository;
            _chatService = chatService;
            _messageHub = messageHub;
            _userManager = userManager;
            _fileService = fileService;
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _messageRepository.GetByIdAsync(id);
        }

        public async Task<List<Message>> GetMessagesByChatIdAsync(int chatId, int page = 0, int pageSize = int.MaxValue)
        {
            var entities = await _messageRepository.GetAllAsync(obj => obj.Where(prp => prp.ChatId == chatId)
                                                                          .Include(prp => prp.Sender)
                                                                          .OrderByDescending(prp => prp.SendDate)
                                                                          .Skip(page * pageSize)
                                                                          .Take(pageSize));

            return entities.Reverse().ToList();
        }

        public async Task SendMessageAsync(Message entity, byte[] imageBytes)
        {
            var chatEntity = await _chatService.GetByIdAsync(entity.ChatId);
            if (chatEntity == null)
                throw new ArgumentException("Chat doesn't exist!");

            if(imageBytes.Length > 0)
            {
                var path = Path.Combine(FilePathConsts.UserMessagesPath, entity.SenderId);
                entity.ImagePath = await _fileService.UploadFile(imageBytes, path);
            }

            entity.SendDate = DateTime.Now;
            await _messageRepository.AddAsync(entity);

            string friendId;
            if (!string.Equals(chatEntity.UserId, entity.SenderId))
                friendId = chatEntity.UserId;
            else
                friendId = chatEntity.FriendId;

            var friend = await _userManager.FindByIdAsync(friendId);
            if (friend == null)
                throw new Exception("Signal not sent as friend was not found");

            await _messageHub.Clients.Group(friend.UserName).SendMessage(friend.UserName, chatEntity.Id);
        }
    }
}
