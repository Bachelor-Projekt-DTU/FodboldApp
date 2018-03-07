using FodboldApp.Model;
using Realms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace FodboldApp.ViewModel
{
    public class LeagueTableVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<HeadLeagueTable> _headLeagueTableCollection { get; set; } = new ObservableCollection<HeadLeagueTable>();
        public ObservableCollection <HeadLeagueTable> HeadLeagueTableCollection {
            get
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
                    var promotionGroup = HeadLeagueTableCollection.Where(x => x.GroupName == item.GroupName);
                    if (promotionGroup.Count() == 0)
                    {
                        var temp = new HeadLeagueTable { GroupName = item.GroupName };
                        temp.LeagueTableCollection.Add(item);
                        HeadLeagueTableCollection.Add(temp);
                    } else
                    {
                        promotionGroup.First().LeagueTableCollection.Add(item);
                    }
                }
            });
            Console.WriteLine("Heeer " + HeadLeagueTableCollection.Count()+" "+HeadLeagueTableCollection.First().LeagueTableCollection.Count);
        }
        
        public LeagueTableVM()
        {
            SetupRealm();
        }

        public class HeadLeagueTable 
        {
            public string GroupName { get; set; }
            public ObservableCollection<LeagueTableModel> LeagueTableCollection { get; set; } = new ObservableCollection<LeagueTableModel>();
        }
    }
}
