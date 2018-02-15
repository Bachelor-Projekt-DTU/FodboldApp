using FodboldApp.Customs;
using FodboldApp.View;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class ClubVM : INotifyPropertyChanged
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

        public ICommand ContinueCommand { get; set; }
        public static IEnumerable<ClubModel> _clubListSource = new ObservableCollection<ClubModel>();
        public IEnumerable<ClubModel> ClubListSource
        {
            get
            {
                return _clubListSource;
            }
            set
            {
                _clubListSource = value;
                OnPropertyChanged(nameof(ClubListSource));
            }
        }

        public ClubModel _selectedItem { get; set; }
        public ClubModel SelectedItem
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

                        OnPropertyChanged(nameof(SelectedItem));
                    });
                }
            }
        }
        void OnTapped()
        {
            Application.Current.MainPage = new CustomNavigationPage(new MainPage());
        }

        public async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("realm-admin", "bachelor", false), new Uri($"http://13.59.205.12:9080"));
            SyncConfiguration config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/clubs"));
            _realm = Realm.GetInstance(config);
            //_realm.Write(() =>
            //{
            //    _realm.RemoveAll();
            //    _realm.Add(new ClubModel { ClubName = "BK Frem" });
            //    _realm.Add(new ClubModel { ClubName = "Klub 2" });
            //    _realm.Add(new ClubModel { ClubName = "Klub 3" });
            //    _realm.Add(new ClubModel { ClubName = "Klub 4" });
            //    _realm.Add(new ClubModel { ClubName = "Klub 5" });
            //});
            ClubListSource = _realm.All<ClubModel>();
            //_realm.Dispose();
        }

        public ClubVM()
        {
            SetupRealm();
           
            ContinueCommand = new Command(OnTapped);
        }
    }
}
