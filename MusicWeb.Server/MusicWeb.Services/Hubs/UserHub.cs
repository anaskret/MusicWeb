using Microsoft.AspNetCore.SignalR;
using MusicWeb.Services.Interfaces.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Services.Hubs
{
    public class UserHub : Hub<IUserHub>
    {
        public async Task SubscribeUserGroup(string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userName);
        }
    }
}
