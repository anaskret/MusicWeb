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
        public async Task SendFriendRequest(string userId, string friendId, string fullName)
        {
            await Clients.All.SendFriendRequest(userId, friendId, fullName);
        }

        public async Task FriendRequestAccepted(string senderId, string accepterId)
        {
            await Clients.Group(senderId).FriendRequestAccepted(senderId, accepterId);
        }
    }
}
