using FodboldApp.Model;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class HistoricalStandingVM : INotifyPropertyChanged
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
        public ICommand HideStackLayoutCommand { get; private set; }
        private IEnumerable<HistoricalStandingTitleModel > _historicalStandingsDataList { get; set; } = new ObservableCollection<HistoricalStandingTitleModel >();
        public IEnumerable<HistoricalStandingTitleModel > HistoricalStandingsDataList
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
        private IEnumerable<HistoricalStandingModel > _historicalStandingsListContent { get; set; } = new ObservableCollection<HistoricalStandingModel >();
        public IEnumerable<HistoricalStandingModel > HistoricalStandingsListContent
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
                return Colorization.ColoringLogic.AppPrimary;
            }
        }
        private string _arrowImage { get; set; } = "down_arrow.png";
        public string ArrowImage {
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
            ShowListView = !_showListView;
            Console.WriteLine("Trykket");
            if (_showListView == true)
            {
                ArrowImage = "up_arrow.png";
            }
            else
            {
                ArrowImage = "down_arrow.png";
            }
        }

        public string tournamentLabelName { get; set; } = "Vælg en turnering";
        public string TournamentLabelName {
            get
            {
                return tournamentLabelName;
            }
            set
            {
                tournamentLabelName = value;
                OnPropertyChanged(nameof(TournamentLabelName));
            }
        }

        public HistoricalStandingModel  _selectedItem { get; set; }
        public HistoricalStandingModel  SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                { 
                    if(_selectedItem != null)
                        _selectedItem.Selected = false;

                    _selectedItem = value;

                    if (_selectedItem != null)
                        _selectedItem.Selected = true;
                        ShowStackLayout = true;

                    TournamentLabelName = _selectedItem.TournamentName;

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        private void SetupHistoricalStandingsDataList()
        {
            _realm.Write(() =>
            {
                _realm.Add(new HistoricalStandingTitleModel { Title = "LANDSFODBOLDTURNERINGEN" });
                _realm.Add(new HistoricalStandingTitleModel { Title = "MESTERSKABSSERIEN" });
                _realm.Add(new HistoricalStandingTitleModel { Title = "Kriseturneringen – kreds 3" });
                _realm.Add(new HistoricalStandingTitleModel { Title = "DANMARKSTURNERINGEN – 1. Division" });
                _realm.Add(new HistoricalStandingTitleModel { Title = "DANMARKSTURNERINGEN – 2. Division" });
            });
            _historicalStandingsDataList = _realm.All<HistoricalStandingTitleModel>();
        }
        private void SetupHistoricalStandingsListContent()
        {
            _realm.Write(() =>
            {
                _realm.Add(new HistoricalStandingModel { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
                _realm.Add(new HistoricalStandingModel { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
                _realm.Add(new HistoricalStandingModel { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
                _realm.Add(new HistoricalStandingModel { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
                _realm.Add(new HistoricalStandingModel { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
            });
            _historicalStandingsListContent = _realm.All<HistoricalStandingModel>();
        }

        public HistoricalStandingVM()
        {
            _realm = Realm.GetInstance();
            SetupHistoricalStandingsDataList();
            SetupHistoricalStandingsListContent();
            HideStackLayoutCommand = new Command(OnTapped);
        }
    }
}
