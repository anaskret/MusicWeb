using Microsoft.AspNetCore.Mvc;
using MusicWeb.Services.Interfaces.Chats;
using MusicWeb.Models.Constants;
using MusicWeb.Models.Dtos.Chats.Base;
using System.Threading.Tasks;
using System;
using AutoMapper;
using MusicWeb.Models.Entities;
using System.Collections.Generic;
using MusicWeb.Models.Dtos.Chats;

namespace MusicWeb.Api.Controllers.Chats
{
    [ApiController]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService chatService, 
            IMapper mapper)
        {
            _chatService = chatService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Chats.GetUserChats)]
        public async Task<IActionResult> GetChats([FromRoute] string id)
        {
            try
            {
                var entities = await _chatService.GetChatsByUserId(id);
                var models = _mapper.Map<List<ChatWithUserNamesDto>>(entities);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Chats.Create)]
        public async Task<IActionResult> Create([FromBody] BaseChatDto chat)
        {
            try
            {
                var entity = _mapper.Map<Chat>(chat);
                var chatId = await _chatService.AddChat(entity);

                return Ok(chatId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Chats.Update)]
        public async Task<IActionResult> Update([FromBody] ChatDto chat)
        {
            try
            {
                var entity = _mapper.Map<Chat>(chat);
                await _chatService.UpdateChat(entity);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Chats.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await _chatService.DeleteChat(id);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(ApiRoutes.Chats.ChatOpened)]
        public async Task<IActionResult> ChatOpened([FromBody] ChatOpenedDto dto)
        {
            try
            {
                await _chatService.ChatOpenedAsync(dto.ChatId, dto.UserId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
