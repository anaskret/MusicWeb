using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Moq;
using MusicWeb.Models.Entities;
using MusicWeb.Models.Identity;
using MusicWeb.Repositories.Interfaces.Chats;
using MusicWeb.Services.Hubs;
using MusicWeb.Services.Interfaces.Chats;
using MusicWeb.Services.Interfaces.Files;
using MusicWeb.Services.Interfaces.Hubs;
using MusicWeb.Services.Services.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicWeb.Tests.Messages
{
    public class MessageServiceTests
    {
        private Mock<IMessageRepository> _messageRepository;
        private Mock<IChatService> _chatService;
        private Mock<IHubContext<MessageHub, IMessageHub>> _messageHub;
        private Mock<UserManager<ApplicationUser>> _userManager;
        private Mock<IFileService> _fileService;

        public MessageServiceTests()
        {
            _messageRepository = new Mock<IMessageRepository>();
            _chatService = new Mock<IChatService>();
            _messageHub = new Mock<IHubContext<MessageHub, IMessageHub>>();
            var store = new Mock<IUserStore<ApplicationUser>>();
            _userManager = new Mock<UserManager<ApplicationUser>>(store.Object, null, null, null, null, null, null, null, null);
            _fileService = new Mock<IFileService>();
        }

        [Fact]
        public async Task SendMessage_ShoudSendSignal()
        {
            _chatService
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Chat()))
                .Verifiable();

            _messageRepository
                .Setup(x => x.AddAsync(It.IsAny<Message>()))
                .Verifiable();

            _userManager
                .Setup(x => x.FindByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new ApplicationUser()));

            _messageHub
                .Setup(x => x.Clients.Group(It.IsAny<string>()).SendMessage(It.IsAny<string>(), It.IsAny<int>()))
                .Verifiable();

            var messageService = new MessageService(
                _messageRepository.Object, 
                _chatService.Object,
                _messageHub.Object,
                _userManager.Object, 
                _fileService.Object);

            await messageService.SendMessageAsync(new Message(), Array.Empty<byte>());

            _chatService.Verify(x => x.GetByIdAsync(It.IsAny<int>()));
            _messageRepository.Verify(x => x.AddAsync(It.IsAny<Message>()));
            _userManager.Verify(x => x.FindByIdAsync(It.IsAny<string>()));
            _messageHub.Verify(x => x.Clients.Group(It.IsAny<string>()).SendMessage(It.IsAny<string>(), It.IsAny<int>()));
        }

        [Fact]
        public async Task ReadMessage_ShoudSendSignal()
        {
            _chatService
                .Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Chat()))
                .Verifiable();

            _messageRepository
                .Setup(x => x.UpdateRangeAsync(It.IsAny<List<Message>>()))
                .Verifiable();
            
            _messageRepository
                .Setup(x => x.GetAllAsync(It.IsAny<Func<IQueryable<Message>, IQueryable<Message>>>()))
                .Returns(Task.FromResult<IList<Message>>(new List<Message>()))
                .Verifiable();

            _messageHub
                .Setup(x => x.Clients.Group(It.IsAny<string>()).MessagesRead(It.IsAny<string>(), It.IsAny<int>()))
                .Verifiable();

            var messageService = new MessageService(
                _messageRepository.Object, 
                _chatService.Object,
                _messageHub.Object,
                _userManager.Object, 
                _fileService.Object);

            await messageService.ReadMessagesAsync(0, "");

            _chatService.Verify(x => x.GetByIdAsync(It.IsAny<int>()));
            _messageRepository.Verify(x => x.GetAllAsync(It.IsAny<Func<IQueryable<Message>, IQueryable<Message>>>()));
            _messageRepository.Verify(x => x.UpdateRangeAsync(It.IsAny<List<Message>>()));
            _messageHub.Verify(x => x.Clients.Group(It.IsAny<string>()).MessagesRead(It.IsAny<string>(), It.IsAny<int>()));
        }
    }
}
