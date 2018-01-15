using FodboldApp.Stack;
using System;
using System.ComponentModel;
using Xamarin.Forms;


namespace FodboldApp.ViewModel
{
    class HeaderViewModel : INotifyPropertyChanged
    {
        Color SelectedColor = Color.FromHex("#315baa");
        Color UnSelectedColor = Color.FromHex("#545454");


        private Color _newsIconColor;
        private Color _playerIconColor;
        private Color _matchIconColor;
        private Color _tournamentIconColor;
        private Color _historyIconColor;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
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
                OnPropertyChanged(nameof(NewsIconColor));
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
                OnPropertyChanged(nameof(NewsIconColor));
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
                OnPropertyChanged(nameof(NewsIconColor));
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
                OnPropertyChanged(nameof(NewsIconColor));
            }
        }

        public CustomStack stack;

        public HeaderViewModel()
        {
            stack = CustomStack.Instance;

            NewsIconColor = SelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;
        }

        private void ResetTint()
        {
            NewsIconColor = UnSelectedColor;
            PlayerIconColor = UnSelectedColor;
            MatchIconColor = UnSelectedColor;
            TournamentIconColor = UnSelectedColor;
            HistoryIconColor = UnSelectedColor;
        }

        public async void NewsTap()
        {
            ResetTint();
            NewsIconColor = SelectedColor;
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is News)
            {
                await stack.NewsContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.NewsContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for(int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.NewsContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }
                
                while(page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }
                
            }
        }

        public async void PlayerTap()
        {
            ResetTint();
            PlayerIconColor = SelectedColor;
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Players)
            {
                await stack.PlayerContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.PlayerContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.PlayerContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }

        public async void MatchTap()
        {
            ResetTint();
            MatchIconColor = SelectedColor;
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Matches)
            {
                await stack.MatchContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.MatchContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.MatchContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }

        public async void TournamentTap()
        {
            ResetTint();
            TournamentIconColor = SelectedColor;
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is Tournament)
            {
                await stack.TournamentContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.TournamentContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.TournamentContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }
            }
        }

        public async void HistoryTap()
        {
            ResetTint();
            HistoryIconColor = SelectedColor;
            if (Application.Current.MainPage.Navigation.NavigationStack[0] is History)
            {
                await stack.HistoryContent.Navigation.PopToRootAsync();
                await Application.Current.MainPage.Navigation.PopToRootAsync();
            }
            else
            {
                int stackSize = stack.HistoryContent.Navigation.NavigationStack.Count;
                Console.WriteLine(stackSize);
                var page = Application.Current.MainPage;
                for (int i = 0; i < stackSize; i++)
                {
                    page.Navigation.InsertPageBefore(stack.HistoryContent.Navigation.NavigationStack[i], page.Navigation.NavigationStack[i]);
                }

                while (page.Navigation.NavigationStack.Count > stackSize)
                {
                    Console.WriteLine(stackSize);
                    await page.Navigation.PopAsync();
                }

            }
        }
    }
}
