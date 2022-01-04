using Microsoft.AspNetCore.SignalR;
using MusicWeb.Services.Interfaces.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Services.Hubs
{
    public class FriendsHub : Hub<IFriendsHub>
    {
        public async Task SendFriendRequest(string userName, string friendUserName, string fullName)
        {
            await Clients.Group(friendUserName).SendFriendRequest(userName, friendUserName, fullName);
        }

        public async Task FriendRequestAccepted(string senderUserName, string accepterUserName, string fullName)
        {
            await Clients.Group(senderUserName).FriendRequestAccepted(senderUserName, accepterUserName, fullName);
        }
    }
}