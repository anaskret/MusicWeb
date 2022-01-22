using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWeb.Admin.Pages.Settings.Models
{
    public class RootUserListModel : INotifyPropertyChanged
    {
        private List<UserListModel> _userList;

        public List<UserListModel> UserList
        {
            get => _userList;
            set
            {
                if (value != _userList)
                {
                    _userList = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(UserList)));
                }
            }
        }

        public RootUserListModel()
        {
            UserList = new List<UserListModel>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
