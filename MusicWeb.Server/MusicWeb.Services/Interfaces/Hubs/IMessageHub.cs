using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicWeb.Services.Interfaces.Hubs
{
    public interface IMessageHub
    {
        Task SendMessage(string friendId, int messageId);
    }
}
