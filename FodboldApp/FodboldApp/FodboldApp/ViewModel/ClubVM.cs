using FodboldApp.Customs;
using FodboldApp.View;
using Realms;
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

        public ClubVM()
        {
            _realm = Realm.GetInstance();
            _realm.Write(() =>
            {
                _realm.Add(new ClubModel { ClubName = "BK Frem" });
                _realm.Add(new ClubModel { ClubName = "Klub 2" });
                _realm.Add(new ClubModel { ClubName = "Klub 3" });
                _realm.Add(new ClubModel { ClubName = "Klub 4" });
                _realm.Add(new ClubModel { ClubName = "Klub 5" });
            });
            _clubListSource = _realm.All<ClubModel>();
            ContinueCommand = new Command(OnTapped);
        }
    }
}
