using FodboldApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class HistoricalStandingVM : HistoricalStandingsData, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private static ObservableCollection<HistoricalStandingsData> HistoricalStandingsDataList = new ObservableCollection<HistoricalStandingsData>();
        private static ObservableCollection<HistoricalStandingsData> HistoricalStandingsListContent = new ObservableCollection<HistoricalStandingsData>();
        public ICommand HideStackLayoutCommand { get; private set; }
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

        public HistoricalStandingsData _selectedItem { get; set; }
        public HistoricalStandingsData SelectedItem
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
      
        public ObservableCollection<HistoricalStandingsData> StandingsListSource
        {
            get
            {
                return HistoricalStandingsDataList;
            }
            set
            {
                HistoricalStandingsDataList = value;
                OnPropertyChanged(nameof(StandingsListSource));
            }
        }
        public ObservableCollection<HistoricalStandingsData> StandingsListSourceContent
        {
            get
            {
                return HistoricalStandingsListContent;
            }
            set
            {
                HistoricalStandingsListContent = value;
                OnPropertyChanged(nameof(StandingsListSourceContent));
            }
        }

        private void SetupHistoricalStandingsDataList()
        {
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "LANDSFODBOLDTURNERINGEN" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "Kriseturneringen – kreds 3" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "DANMARKSTURNERINGEN – 1. Division" });
            HistoricalStandingsDataList.Add(new HistoricalStandingsData { TournamentName = "DANMARKSTURNERINGEN – 2. Division" });

        }
        private void SetupHistoricalStandingsListContent()
        {
            HistoricalStandingsListContent.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
            HistoricalStandingsListContent.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
            HistoricalStandingsListContent.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
            HistoricalStandingsListContent.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
            HistoricalStandingsListContent.Add(new HistoricalStandingsData { TournamentName = "MESTERSKABSSERIEN", Year = "1929-30", Games = "9", Record = "6-3-0", Standing = "1", Points = "15" });
        }

        public HistoricalStandingVM()
        {
            SetupHistoricalStandingsDataList();
            SetupHistoricalStandingsListContent();
            HideStackLayoutCommand = new Command(OnTapped);
        }
    }
}
