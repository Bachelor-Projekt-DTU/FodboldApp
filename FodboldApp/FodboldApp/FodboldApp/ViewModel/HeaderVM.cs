using FodboldApp.Stack;
using FodboldApp.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using static FodboldApp.Model.Categories;

namespace FodboldApp.ViewModel
{
    class HeaderVM : INotifyPropertyChanged
    {
        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");

        public ICommand NewsTapped { get; private set; }
        public ICommand PlayersTapped { get; private set; }
        public ICommand MatchesTapped { get; private set; }
        public ICommand TournamentTapped { get; private set; }
        public ICommand HistoryTapped { get; private set; }
        public ICommand LoginCommand { get; private set; }
        public ICommand BackButtonTapped { get; private set; }

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
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public static void SetContent(ContentView content)
        {
            contentPage = content;
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

        public static CustomStack stack;

        public HeaderVM()
        {
            stack = CustomStack.Instance;
            ResetTint();
            
            NewsTapped = new Command(NewsTap);
            PlayersTapped = new Command(PlayerTap);
            MatchesTapped = new Command(MatchTap);
            TournamentTapped = new Command(TournamentTap);
            HistoryTapped = new Command(HistoryTap);
            LoginCommand = new Command(Login);
            BackButtonTapped = new Command(BackButtonPressed);
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

        public async void NewsTap()
        {
            ResetTint();
            NewsIconColor = SelectedColor;
            if (currentCategory == CategoryType.NewsType)
            {
                await stack.NewsContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.NewsType;
            contentPage.Content = ((ContentPage)stack.NewsContent.CurrentPage).Content;
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
            contentPage.Content = ((ContentPage)stack.PlayerContent.CurrentPage).Content;
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
            contentPage.Content = ((ContentPage)stack.MatchContent.CurrentPage).Content;
        }

        public async void TournamentTap()
        {
            ResetTint();
            TournamentIconColor = SelectedColor;
            if (currentCategory == CategoryType.TournamentType)
            {
                await stack.TournamentContent.Navigation.PopToRootAsync();
            }
            currentCategory = CategoryType.TournamentType;
            contentPage.Content = ((ContentPage)stack.TournamentContent.CurrentPage).Content;
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
            contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
        }

        public static void UpdateContent()
        {
            switch(currentCategory)
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
                    contentPage.Content = ((ContentPage)stack.TournamentContent.CurrentPage).Content;
                    break;
                case CategoryType.HistoryType:
                    contentPage.Content = ((ContentPage)stack.HistoryContent.CurrentPage).Content;
                    break;
            }
        }

        public static async void BackButtonPressed()
        {
            switch(currentCategory)
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
                    await stack.TournamentContent.Navigation.PopAsync();
                    break;
                case CategoryType.HistoryType:
                    await stack.HistoryContent.Navigation.PopAsync();
                    break;
            }
            UpdateContent();
        }
    }
}
