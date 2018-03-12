using FodboldApp.Model;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class ChatVM : INotifyPropertyChanged   
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ChatCommand { get; private set; }

        private bool _isChatRoomOpen { get; set; } = true;
        public bool IsChatRoomOpen
        {
            get
            {
                return _isChatRoomOpen;
            }
            set
            {
                _isChatRoomOpen = value;
                OnPropertyChanged(nameof(IsChatRoomOpen));
                OnPropertyChanged(nameof(IsEditorVisible));
            }
        }

        public bool IsEditorVisible
        {
            get
            {
                return ViewModelLocator.HeaderVM.IsUserLoggedIn && _isChatRoomOpen;
            }
        }

        private string _userChatMessage { get; set; }
        public string UserChatMessage
        {
            get
            {
                return _userChatMessage;
            }
            set
            {
                _userChatMessage = value;
                OnPropertyChanged(nameof(UserChatMessage));
            }
        }

        private IEnumerable<ChatModel> _chatList { get; set; }
        public IEnumerable<ChatModel> ChatList
        {
            get
            {
                return _chatList;
            }
            set
            {
                _chatList = value;
                OnPropertyChanged(nameof(ChatList));
            }
        }

        public ChatVM()
        {
            SetupRealm();
        }

        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/chat"));
            _realm = Realm.GetInstance(config);

            ChatCommand = new Command(ChatSend);

            ChatList = _realm.All<ChatModel>();
        }

        public void ChatSend()
        {
            _realm.Write(() =>
            {
                _realm.Add(new ChatModel { Content = _userChatMessage, Admin = false, MatchID = "1234" });
            });
        }
    }
}
