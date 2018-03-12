using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System.ComponentModel;
using System.Linq;
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
            NewsList = _realm.All<NewsModel>();
        }

        public NewsVM()
        {
            SetupRealm();
            NewsCommand = new Command(News_Tapped);
        }

        void News_Tapped()
        {
            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage(SelectedItem));
            ViewModelLocator.HeaderVM.UpdateContent();
        }
    }
}
