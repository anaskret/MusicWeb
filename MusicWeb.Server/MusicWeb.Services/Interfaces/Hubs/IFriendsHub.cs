using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Hubs
{
    public interface IFriendsHub
    {
        Task SubscribeUserGroup(string userName);
        Task SendFriendRequest(string userName, string friendUserName, string fullName);
        Task FriendRequestAccepted(string senderUserName, string accepterUserName, string fullName);
    }
}
