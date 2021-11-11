using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Hubs
{
    public interface IFriendsHub
    {
        Task SendFriendRequest(string userId, string friendId);
        Task FriendRequestAccepted(string senderId, string accepterId);
    }
}
