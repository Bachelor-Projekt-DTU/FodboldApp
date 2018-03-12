﻿using FodboldApp.Model;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
        private IEnumerable<HistoricalStandingModel> _historicalStandingsListContent { get; set; } = new ObservableCollection<HistoricalStandingModel >();
        public IEnumerable<HistoricalStandingModel> HistoricalStandingsListContent
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
            if (_showListView)
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

        public HistoricalStandingTitleModel  _selectedItem { get; set; }
        public HistoricalStandingTitleModel  SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _realm.Write(() =>
                    {
                        if (_selectedItem != null)
                            _selectedItem.Selected = false;

                        _selectedItem = value;

                        if (_selectedItem != null)
                            _selectedItem.Selected = true;
                        ShowStackLayout = true;

                        TournamentLabelName = _selectedItem.Title;

                        OnPropertyChanged(nameof(SelectedItem));
                    });
                }
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("historicalStandings");

            HistoricalStandingsDataList = _realm.All<HistoricalStandingTitleModel>();
            HistoricalStandingsListContent = _realm.All<HistoricalStandingModel>();
        }

        public HistoricalStandingVM()
        {
            SetupRealm();
            
            HideStackLayoutCommand = new Command(OnTapped);
        }
    }
}
