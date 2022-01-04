﻿using Microsoft.AspNetCore.SignalR;
using MusicWeb.Services.Interfaces.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Hubs
{
    public class MessageHub : Hub<IMessageHub>
    {
        public async Task SendMessage(string friendUserName, int messageId)
        {
            await Clients.Group(friendUserName).SendMessage(friendUserName, messageId);
        }
    }
}