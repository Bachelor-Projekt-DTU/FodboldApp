using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class NewsVM : INotifyPropertyChanged
    {
        private Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand NewsCommand { get; private set; }
        public string TestText { get; } = "NÆSTE KAMP";

        private IQueryable<NewsModel> _newsList;
        public IQueryable<NewsModel> NewsList
        {
            get
            {
                return _newsList;
            }
            set
            {
                _newsList = value;
                OnPropertyChanged(nameof(NewsList));
            }
        }
        private NewsModel _selectedItem { get; set; }
        public NewsModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("news");
            //var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            //SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/news"));
            //_realm = Realm.GetInstance(config);
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new NewsModel { Title = "U23 kommet godt fra start", Date = "10. august 2017", Resume = "Siden 20 juli har Boldklubben FREMs nye setup været igang. Truppen begynder at tage form, og skarpheden til træning og i kamp viser en klar positiv tendens.", ImageURL = "http://www.bkfrem.dk/images/image2(9).JPG" });
            //    _realm.Add(new NewsModel() { Title = "Exit i pokalen", Date = "8. august 2017", Resume = "1 runde blev endestationen. Et feststemt stadion i Hvidovre med flotte 1.126 tilskuere på lægterne blev vidne til et opgør, hvor hjemmeholdet straks fra start trykkede på for at få et hurtigt...", ImageURL = "http://www.bkfrem.dk/images/20746806_1630657970299346_218944165_o.jpg" });
            //});
            NewsList = _realm.All<NewsModel>();
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAY" + NewsList.Count());
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAY" + _realm==null);
        }

        public NewsVM()
        {
            SetupRealm();
            NewsCommand = new Command(News_Tapped);
        }

        void News_Tapped()
        {
            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage(SelectedItem));
            HeaderVM.UpdateContent();
        }
    }
}
