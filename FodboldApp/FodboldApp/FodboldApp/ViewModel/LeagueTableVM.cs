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

namespace FodboldApp.ViewModel
{
    class LeagueTableVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection <HeadLeagueTable> _headLeagueTableCollection { get; set; }
        public ObservableCollection <HeadLeagueTable> HeadLeagueTableCollection { get
            {
                return _headLeagueTableCollection;
            }
            set
            {
                _headLeagueTableCollection = value;
                OnPropertyChanged(nameof(HeadLeagueTableCollection));
            }
        }

        private IQueryable<LeagueTableModel> _leagueTable { get; set; }
        public IQueryable<LeagueTableModel> LeagueTable
        {
            get
            {
                return _leagueTable;
            }
            set
            {
                _leagueTable = value;
                OnPropertyChanged(nameof(LeagueTable));
            }
        }
        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("standings");
            LeagueTable = _realm.All<LeagueTableModel>();
            int i = 0;
            _realm.Write(() =>
            {
                foreach (var item in LeagueTable)
                {
                    item.Index = i++;
                }
            });
        }
        
        public LeagueTableVM()
        {
            SetupRealm();
        }

        public class HeadLeagueTable
        {
            public string GroupName { get; set; }
            public ObservableCollection<LeagueTableModel> LeagueTableCollection = new ObservableCollection<LeagueTableModel>();
        }
    }
}
