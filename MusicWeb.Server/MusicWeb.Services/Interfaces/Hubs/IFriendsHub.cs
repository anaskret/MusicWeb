using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Hubs
{
    public interface IFriendsHub
    {
        Task SendFriendRequest(string userId, string friendId, string fullName);
        Task FriendRequestAccepted(string senderId, string accepterId);
        Task SubscribeUserGroup(string userId);
    }
}
