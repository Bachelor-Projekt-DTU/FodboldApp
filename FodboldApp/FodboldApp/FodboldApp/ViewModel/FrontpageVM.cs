using FodboldApp.Customs;
using FodboldApp.Model;
using Realms;
using Realms.Sync;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

namespace FodboldApp.ViewModel
{
    class FrontpageVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ContinueCommand { get; set; }

        public static IQueryable<ClubModel> _clubListSource;
        public IQueryable<ClubModel> ClubListSource
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

        async void SetupRealm()
        {
            var user = await User.LoginAsync(Credentials.UsernamePassword("StandardUser", "12345", false), new Uri($"http://13.59.205.12:9080"));
            var config = new SyncConfiguration(user, new Uri($"realm://13.59.205.12:9080/data/clubs"));
            _realm = Realm.GetInstance(config);
            
            ClubListSource = _realm.All<ClubModel>();
        }

        public FrontpageVM()
        {
            SetupRealm();
            ContinueCommand = new Command(OnTapped);
        }
    }
}
