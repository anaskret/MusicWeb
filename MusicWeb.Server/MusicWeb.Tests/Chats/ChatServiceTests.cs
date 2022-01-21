using FluentAssertions;
using Moq;
using MusicWeb.Models.Entities;
using MusicWeb.Repositories.Interfaces.Chats;
using MusicWeb.Services.Services.Chats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MusicWeb.Tests.Chats
{
    public class ChatServiceTests
    {
        private readonly Mock<IChatRepository> _chatRepository;

        public ChatServiceTests()
        {
            _chatRepository = new Mock<IChatRepository>();
        }

        [Fact]
        public async Task AddChat_ShouldThrowArgumentException()
        {
            _chatRepository
                .Setup(x => x.GetSingleAsync(It.IsAny<Expression<Func<Chat, bool>>>()))
                .Returns(Task.FromResult(new Chat()))
                .Verifiable();

            var chatService = new ChatService(_chatRepository.Object);

            Func<Task> act = async () => await chatService.AddChat(new Chat());

            await act.Should().ThrowAsync<ArgumentException>();
            _chatRepository.Verify(x => x.GetSingleAsync(It.IsAny<Expression<Func<Chat, bool>>>()), Times.Once);
        }
    }
}
