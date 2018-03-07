using FodboldApp.Globals;
using FodboldApp.Interfaces;
using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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
        private static bool HasInternet = true;

        public ICommand NewsTapped { get; private set; }
        public ICommand PlayersTapped { get; private set; }
        public ICommand MatchesTapped { get; private set; }
        public ICommand TournamentTapped { get; private set; }
        public ICommand HistoryTapped { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand LogoutCommand { get; private set; }
        public ICommand BackButtonTapped { get; private set; }
        public ICommand ArticleCommand { get; private set; }

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

        public static void SetContent(ContentView content)
        {
            contentPage = content;
        }

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

        private async System.Threading.Tasks.Task FilterArticlesAsync()
        {
            if (String.IsNullOrEmpty(_inputText))
            {
                SearchResultList = null;
                UpdateContent();
            }
            else
            {
                var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
                SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/news"));
                _realm = Realm.GetInstance(config);
                SearchResultList = _realm.All<NewsModel>().Where(Data => Data.Text.Contains(InputText));
                Console.WriteLine(SearchResultList.Count());
            }
        }

        public void ArticleTap()
        {
            CustomStack.Instance.NewsContent.Navigation.PushAsync(new NewsPage(SelectedItem));
            currentCategory = CategoryType.NewsType;
            UpdateContent();
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
        private NewsModel _selectedItem { get; set; }
        public NewsModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
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
            ViewModelLocator.HeaderVM.IsUserLoggedIn = false;
            if (Application.Current.Properties.ContainsKey("IsUserLoggedIn"))
            {
                Console.WriteLine("Logget af");
                Application.Current.Properties.Remove("IsUserLoggedIn");
            }

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
                await stack.NewsContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.NewsType;
            if (HasInternet) contentPage.Content = ((ContentPage)stack.NewsContent.CurrentPage).Content;
        }

        public async void PlayerTap()
        {
            ResetTint();
            PlayerIconColor = SelectedColor;
            if (currentCategory == CategoryType.PlayerType)
            {
                await stack.PlayerContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.PlayerType;
            if (HasInternet) contentPage.Content = ((ContentPage)stack.PlayerContent.CurrentPage).Content;
        }

        public async void MatchTap()
        {
            ResetTint();
            MatchIconColor = SelectedColor;
            if (currentCategory == CategoryType.MatchType)
            {
                await stack.MatchContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.MatchType;
            if (HasInternet) contentPage.Content = ((ContentPage)stack.MatchContent.CurrentPage).Content;
        }

        public async void TournamentTap()
        {
            ResetTint();
            TournamentIconColor = SelectedColor;
            if (currentCategory == CategoryType.TournamentType)
            {
                await stack.LeagueTableContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.TournamentType;
            if (HasInternet) contentPage.Content = ((ContentPage)stack.LeagueTableContent.CurrentPage).Content;
        }

        public async void HistoryTap()
        {
            ResetTint();
            HistoryIconColor = SelectedColor;
            if (currentCategory == CategoryType.HistoryType)
            {
                await stack.HistoryContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.HistoryType;
            if (HasInternet) contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
        }

        public static void UpdateContent()
        {
            switch (currentCategory)
            {
                case CategoryType.NewsType:
                    contentPage.Content = ((ContentPage)stack.NewsContent.CurrentPage).Content;
                    break;
                case CategoryType.PlayerType:
                    contentPage.Content = ((ContentPage)stack.PlayerContent.CurrentPage).Content;
                    break;
                case CategoryType.MatchType:
                    contentPage.Content = ((ContentPage)stack.MatchContent.CurrentPage).Content;
                    break;
                case CategoryType.TournamentType:
                    contentPage.Content = ((ContentPage)stack.LeagueTableContent.CurrentPage).Content;
                    break;
                case CategoryType.HistoryType:
                    contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
                    break;
            }
        }

        public static async void BackButtonPressed()
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

        internal static void ResetStack()
        {
            HasInternet = true;
            CustomStack.ResetStack();
            stack = CustomStack.Instance;
            UpdateContent();
        }
    }
}
