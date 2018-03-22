using FodboldApp.Model;
using Realms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace FodboldApp.ViewModel
{
    class HistoricalStandingVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public ICommand HideStackLayoutCommand { get; private set; }
        private ObservableCollection<HistoricalStandingTitleModel> _historicalStandingsDataList { get; set; } = new ObservableCollection<HistoricalStandingTitleModel>();
        public ObservableCollection<HistoricalStandingTitleModel> HistoricalStandingsDataList
        {
            get
            {
                return _historicalStandingsDataList;
            }
            set
            {
                _historicalStandingsDataList = value;
                OnPropertyChanged(nameof(HistoricalStandingsDataList));
            }
        }

        private IQueryable<HistoricalStandingModel> _queryList { get; set; }
        public IQueryable<HistoricalStandingModel> QueryList
        {
            get
            {
                return _queryList;
            }
            set
            {
                _queryList = value;
                OnPropertyChanged(nameof(QueryList));
            }
        }

        private ObservableCollection<HistoricalStandingModel> _historicalStandingsListContent { get; set; }
        public ObservableCollection<HistoricalStandingModel> HistoricalStandingsListContent
        {
            get
            {
                return _historicalStandingsListContent;
            }
            set
            {
                _historicalStandingsListContent = value;
                OnPropertyChanged(nameof(HistoricalStandingsListContent));
            }
        }

        public bool _showStackLayout { get; set; } = false;
        public bool ShowStackLayout
        {
            get
            {
                return _showStackLayout;
            }
            set
            {
                _showStackLayout = value;
                OnPropertyChanged(nameof(ShowStackLayout));
            }
        }

        public Color TableColor
        {
            get
            {
                return Globals.ColoringLogic.AppPrimary;
            }
        }
        private string _arrowImage { get; set; } = "down_arrow.png";
        public string ArrowImage
        {
            get
            {
                return _arrowImage;
            }
            set
            {
                _arrowImage = value;
                OnPropertyChanged(nameof(ArrowImage));
            }
        }

        public bool _showListView { get; set; } = false;
        public bool ShowListView
        {
            get
            {
                return _showListView;
            }
            set
            {
                _showListView = value;
                OnPropertyChanged(nameof(ShowListView));
            }
        }

        void OnTapped()
        {
            //checks that the database has elements before proceeding
            if (QueryList.Count() > 0)
            {
                //adds first category
                HistoricalStandingsDataList.Add(new HistoricalStandingTitleModel { Title = QueryList.First().TournamentName });

                //checks for each element if there already exists a matching category, adds it if not
                for (int i = 1; i < QueryList.Count(); i++)
                {
                    if (QueryList.ElementAt(i).TournamentName != QueryList.ElementAt(i - 1).TournamentName)
                    {
                        bool add = true;
                        foreach (var item in HistoricalStandingsDataList)
                        {
                            if (item.Title.ToUpper() == QueryList.ElementAt(i).TournamentName.ToUpper()) add = false;
                        }
                        if (add) HistoricalStandingsDataList.Add(new HistoricalStandingTitleModel { Title = QueryList.ElementAt(i).TournamentName });
                    }
                }
                ShowListView = !_showListView;
                if (_showListView)
                {
                    ArrowImage = "up_arrow.png";
                }
                else
                {
                    ArrowImage = "down_arrow.png";
                }
            }
        }

        public string _tournamentLabelName { get; set; } = "Vælg en turnering";
        public string TournamentLabelName
        {
            get
            {
                return _tournamentLabelName;
            }
            set
            {
                _tournamentLabelName = value;
                HistoricalStandingsListContent = new ObservableCollection<HistoricalStandingModel>(QueryList.ToList().Where(x => x.TournamentName.ToUpper().Equals(_tournamentLabelName.ToUpper())).OrderByDescending(x => x.Year));
                OnPropertyChanged(nameof(TournamentLabelName));
            }
        }

        public HistoricalStandingTitleModel _selectedItem { get; set; }
        public HistoricalStandingTitleModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    if (_selectedItem != null)
                        _selectedItem.Selected = false;

                    _selectedItem = value;

                    if (_selectedItem != null)
                        _selectedItem.Selected = true;
                    ShowStackLayout = true;

                    TournamentLabelName = _selectedItem.Title;

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("historicalStandings");
            QueryList = _realm.All<HistoricalStandingModel>().OrderBy(x => x.TournamentName);
        }

        public HistoricalStandingVM()
        {
            SetupRealm();

            HideStackLayoutCommand = new Command(OnTapped);
        }
    }
}
