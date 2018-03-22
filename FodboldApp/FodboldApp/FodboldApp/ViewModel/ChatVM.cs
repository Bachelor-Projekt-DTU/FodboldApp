using FodboldApp.Globals;
using FodboldApp.Model;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

        public string Id { get; set; }

        //used to check whether a user currently can chat
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

        private bool _sendButtonIsVisible { get; set; }
        public bool SendButtonIsVisible
        {
            get
            {
                return _sendButtonIsVisible;
            }
            set
            {
                _sendButtonIsVisible = value;
                OnPropertyChanged(nameof(SendButtonIsVisible));
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

                if (_userChatMessage.Length > 0)
                {
                    LabelIsVisible = false;
                    SendButtonIsVisible = true;
                }
                else
                {
                    LabelIsVisible = true;
                    SendButtonIsVisible = false;
                }
                OnPropertyChanged(nameof(UserChatMessage));
            }
        }

        private bool _labelIsVisible { get; set; } = true;
        public bool LabelIsVisible
        {
            get
            {
                return _labelIsVisible;
            }
            set
            {
                _labelIsVisible = value;
                OnPropertyChanged(nameof(LabelIsVisible));
            }
        }

        public bool IsEditorVisible
        {
            get
            {
                return ViewModelLocator.HeaderVM.IsUserLoggedIn && _isChatRoomOpen;
            }
        }

        private IQueryable<ChatModel> _chatList { get; set; }
        public IQueryable<ChatModel> ChatList
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

        //connects to the database
        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/chat"));
            _realm = Realm.GetInstance(config);

            ChatCommand = new Command(ChatSend);

            ChatList = _realm.All<ChatModel>();
        }

        public void ChatSend()
        {
            _realm.Write(() =>
            {
                _realm.Add(new ChatModel { Content = _userChatMessage, Admin = CurrentUser.IsAdmin, MatchID = Id });
            });
        }
    }
}
