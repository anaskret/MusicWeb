using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicWeb.Api.Extensions;
using MusicWeb.Models.Dtos.Chats;
using MusicWeb.Models.Dtos.Chats.Base;
using MusicWeb.Models.Entities;
using MusicWeb.Services.Interfaces.Chats;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicWeb.Api.Controllers.Chats
{
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet(ApiRoutes.Messages.GetPagedByChatId)]
        public async Task<IActionResult> GetMessages([FromRoute] int id, [FromRoute] int page, [FromRoute] int pageSize)
        {
            try
            {
                var entites = await _messageService.GetMessagesByChatIdAsync(id, page, pageSize);
                var models = _mapper.Map<List<MessageDto>>(entites);
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet(ApiRoutes.Messages.GetMessageById)]
        public async Task<IActionResult> GetMessageById([FromRoute] int id)
        {
            try
            {
                var entity = await _messageService.GetByIdAsync(id);
                if (entity == null)
                    throw new ArgumentException("Message doesn't exist");

                var model = _mapper.Map<MessageDto>(entity);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(ApiRoutes.Messages.Create)]
        public async Task<IActionResult> Create([FromBody] BaseMessageDto model)
        {
            try
            {
                var entity = _mapper.Map<Message>(model);
                await _messageService.SendMessageAsync(entity, model.ImageBytes);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
