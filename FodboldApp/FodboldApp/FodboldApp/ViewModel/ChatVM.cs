using FodboldApp.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FodboldApp.ViewModel
{
    class ChatVM : INotifyPropertyChanged   
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private IEnumerable<ChatModel> _chatList { get; set; } = new ObservableCollection<ChatModel>();
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
            _realm = Realm.GetInstance();
            _realm.Write(() =>
            {
                _realm.Add(new ChatModel { Content = "Besked 1", Admin = false, MatchID = "1234" });
                _realm.Add(new ChatModel { Content = "looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong text", Admin = false, MatchID = "1234" });
                _realm.Add(new ChatModel { Content = "Besked 3", Admin = true, MatchID = "1234" });
                _realm.Add(new ChatModel { Content = "Besked 4", Admin = false, MatchID = "1234" });
            });
            _chatList = _realm.All<ChatModel>();
        }
    }
}
