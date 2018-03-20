using FodboldApp.Globals;
using FodboldApp.Interfaces;
using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static FodboldApp.Model.Categories;

namespace FodboldApp.ViewModel
{
    class HeaderVM : INotifyPropertyChanged
    {
        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");

        Realm _realm;

        //used to check whether the phone is connected to the internet
        private static bool HasInternet = true;

        //used to control visibility of backbutton in header
        private bool _notMainPage { get; set; } = false;
        public bool NotMainPage
        {
            get
            {
                return _notMainPage;
            }
            private set
            {
                _notMainPage = value;
                OnPropertyChanged(nameof(NotMainPage));
            }
        }

        //footer commands
        public ICommand NewsTapped { get; private set; }
        public ICommand PlayersTapped { get; private set; }
        public ICommand MatchesTapped { get; private set; }
        public ICommand TournamentTapped { get; private set; }
        public ICommand HistoryTapped { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand BackButtonTapped { get; private set; }
        public ICommand ArticleCommand { get; private set; }

        //footer colors
        private Color _newsIconColor;
        private Color _playerIconColor;
        private Color _matchIconColor;
        private Color _tournamentIconColor;
        private Color _historyIconColor;
        private static ContentView contentPage;

        private static CategoryType currentCategory;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        //changes the main content of the application
        public static void SetContent(ContentView content)
        {
            contentPage = content;
        }

        //used to search for article
        private string _inputText;
        public string InputText
        {
            get
            {
                return _inputText;
            }
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    contentPage.Content = new SearchResultView().Content;
                    OnPropertyChanged(nameof(InputText));
                    FilterArticlesAsync();
                }
                else
                {
                    UpdateContent();
                }
            }
        }

        //switch to deselect the searchbar
        private bool _searchbarEnabled { get; set; } = true;
        public bool SearchbarEnabled
        {
            get
            {
                return _searchbarEnabled;
            }
            set
            {
                _searchbarEnabled = value;
                OnPropertyChanged(nameof(SearchbarEnabled));
            }
        }

        private IQueryable<NewsModel> _searchResultList;
        public IQueryable<NewsModel> SearchResultList
        {
            get
            {
                return _searchResultList;
            }
            set
            {
                if (_searchResultList != value)
                {
                    _searchResultList = value;
                    OnPropertyChanged(nameof(SearchResultList));
                }
            }
        }

        private async Task FilterArticlesAsync()
        {
            if (String.IsNullOrEmpty(_inputText))
            {
                SearchResultList = null;
                UpdateContent();
            }
            else
            {
                var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
                SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/news"));
                _realm = Realm.GetInstance(config);
                SearchResultList = _realm.All<NewsModel>().Where(Data => Data.Text.Contains(InputText));
            }
        }

        public void ArticleTap()
        {
            InputText = String.Empty;
            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage(SelectedItem));
            
            //disable the searchbar to untoggle it, lets it register before enabling it in another thread
            SearchbarEnabled = false;
            new Task(EnableSeachBar).Start();

            currentCategory = CategoryType.NewsType;
            UpdateContent();
        }

        private void EnableSeachBar()
        {
            Thread.Sleep(500);
            SearchbarEnabled = true;

        }

        public bool _isUserLoggedIn { get; set; }
        public bool IsUserLoggedIn
        {
            get
            {
                return _isUserLoggedIn;
            }
            set
            {
                _isUserLoggedIn = value;
                OnPropertyChanged(nameof(IsUserLoggedIn));
            }
        }
        public enum LoginType { Facebook, Google };
        private LoginType _typeOfLogin { get; set; }
        public LoginType TypeOfLogin
        {
            get
            {
                return _typeOfLogin;
            }
            set
            {
                _typeOfLogin = value;
                OnPropertyChanged(nameof(TypeOfLogin));
            }
        }

        public Color NewsIconColor
        {
            get
            {
                return _newsIconColor;
            }
            private set
            {
                _newsIconColor = value;
                OnPropertyChanged(nameof(NewsIconColor));
            }
        }
        public Color PlayerIconColor
        {
            get
            {
                return _playerIconColor;
            }
            private set
            {
                _playerIconColor = value;
                OnPropertyChanged(nameof(PlayerIconColor));
            }
        }
        public Color MatchIconColor
        {
            get
            {
                return _matchIconColor;
            }
            private set
            {
                _matchIconColor = value;
                OnPropertyChanged(nameof(MatchIconColor));
            }
        }
        public Color TournamentIconColor
        {
            get
            {
                return _tournamentIconColor;
            }
            private set
            {
                _tournamentIconColor = value;
                OnPropertyChanged(nameof(TournamentIconColor));
            }
        }

        public Color HistoryIconColor
        {
            get
            {
                return _historyIconColor;
            }
            private set
            {
                _historyIconColor = value;
                OnPropertyChanged(nameof(HistoryIconColor));
            }
        }

        //used to get selected article on search
        private NewsModel _selectedItem { get; set; }
        public NewsModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }

        public static CustomStack stack;

        public HeaderVM()
        {
            ResetTint();
            NewsTapped = new Command(NewsTap);
            PlayersTapped = new Command(PlayerTap);
            MatchesTapped = new Command(MatchTap);
            TournamentTapped = new Command(TournamentTap);
            HistoryTapped = new Command(HistoryTap);
            LoginCommand = new Command(Login);
            LogoutCommand = new Command(Logout);
            BackButtonTapped = new Command(BackButtonPressed);
            ArticleCommand = new Command(ArticleTap);
        }

        public void CreateStack()
        {
            stack = CustomStack.Instance;
        }

        //colors all footer icons grey
        private void ResetTint()
        {
            NewsIconColor = UnSelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;
        }

        public async void Login()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new Login());
        }

        public void Logout()
        {
            CurrentUser.IsAdmin = false;
            ViewModelLocator.HeaderVM.IsUserLoggedIn = false;
            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                Application.Current.Properties.Remove("IsUserLoggedIn");
            }

            //Checks which service to log out from
            if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Google)
            {
                DependencyService.Get<ILogOut>().LogOutGoogle();
                Application.Current.Properties.Remove("Token");
                GooglePlusSingleton.Instance.RemoveToken();
                GooglePlusSingleton.Instance.ResetAuthentication();
                CurrentUser.user = new UserModel();
            }
            else if (ViewModelLocator.HeaderVM.TypeOfLogin == HeaderVM.LoginType.Facebook)
            {
                DependencyService.Get<ILogOut>().LogOutFB();
                Application.Current.Properties.Remove("Token");
                FacebookSingleton.Instance.RemoveToken();
                FacebookSingleton.Instance.ResetAuthentication();
                CurrentUser.user = new UserModel();
            }
        }

        public async void NewsTap()
        {
            ResetTint();
            NewsIconColor = SelectedColor;
            if (currentCategory == CategoryType.NewsType)
            {
                NotMainPage = false;
                await stack.NewsContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.NewsType;
            if (HasInternet) UpdateContent();
        }

        public async void PlayerTap()
        {
            ResetTint();
            PlayerIconColor = SelectedColor;
            if (currentCategory == CategoryType.PlayerType)
            {
                NotMainPage = false;
                await stack.PlayerContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.PlayerType;
            if (HasInternet) UpdateContent();
        }

        public async void MatchTap()
        {
            ResetTint();
            MatchIconColor = SelectedColor;
            if (currentCategory == CategoryType.MatchType)
            {
                NotMainPage = false;
                await stack.MatchContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.MatchType;
            if (HasInternet) UpdateContent();
        }

        public async void TournamentTap()
        {
            ResetTint();
            TournamentIconColor = SelectedColor;
            if (currentCategory == CategoryType.TournamentType)
            {
                NotMainPage = false;
                await stack.LeagueTableContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.TournamentType;
            if (HasInternet) UpdateContent();
        }

        public async void HistoryTap()
        {
            ResetTint();
            HistoryIconColor = SelectedColor;
            if (currentCategory == CategoryType.HistoryType)
            {
                NotMainPage = false;
                await stack.HistoryContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.HistoryType;
            if (HasInternet) UpdateContent();
        }

        //sets the content of the main page according to selected tab and checks for backbutton visibility
        public void UpdateContent()
        {
            ContentPage contemp = null;
            switch (currentCategory)
            {
                case CategoryType.NewsType:
                    contemp = ((ContentPage)stack.NewsContent.CurrentPage);
                    break;
                case CategoryType.PlayerType:
                    contemp = ((ContentPage)stack.PlayerContent.CurrentPage);
                    break;
                case CategoryType.MatchType:
                    contemp = ((ContentPage)stack.MatchContent.CurrentPage);
                    break;
                case CategoryType.TournamentType:
                    contemp = ((ContentPage)stack.LeagueTableContent.CurrentPage);
                    break;
                case CategoryType.HistoryType:
                    contemp = ((ContentPage)stack.HistoryContent.CurrentPage);
                    break;
            }
            if (contemp.Navigation.NavigationStack.Count == 1)
            {
                NotMainPage = false;
            }
            else NotMainPage = true;
            contentPage.Content = contemp.Content;
        }

        //pops the currently selected navigationpage
        public async void BackButtonPressed()
        {
            switch (currentCategory)
            {
                case CategoryType.NewsType:
                    await stack.NewsContent.Navigation.PopAsync();
                    break;
                case CategoryType.PlayerType:
                    await stack.PlayerContent.Navigation.PopAsync();
                    break;
                case CategoryType.MatchType:
                    await stack.MatchContent.Navigation.PopAsync();
                    break;
                case CategoryType.TournamentType:
                    await stack.LeagueTableContent.Navigation.PopAsync();
                    break;
                case CategoryType.HistoryType:
                    await stack.HistoryContent.Navigation.PopAsync();
                    break;
            }
            UpdateContent();
        }

        public void NoInternetHandler()
        {
            HasInternet = false;
            contentPage.Content = new NoInternetPage().Content;
        }

        internal void ResetStack()
        {
            HasInternet = true;
            CustomStack.ResetStack();
            stack = CustomStack.Instance;
            UpdateContent();
        }
    }
}
