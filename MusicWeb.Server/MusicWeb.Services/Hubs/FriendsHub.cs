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
        public static List<string> GroupsTest { get; set; } = new List<string>();

        public async Task SubscribeUserGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "1");
            GroupsTest.Add(userId);
        }

        public async Task SendFriendRequest(string userId, string friendId, string fullName)
        {
            await Clients.Group("1").SendFriendRequest(userId, friendId, fullName);
        }

        public async Task FriendRequestAccepted(string senderId, string accepterId)
        {
            await Clients.Group(senderId).FriendRequestAccepted(senderId, accepterId);
        }
    }
}