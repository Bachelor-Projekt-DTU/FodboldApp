using FodboldApp.Customs;
using FodboldApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class ClubVM : ClubsData
    {
        public ICommand ContinueCommand { get; set; }
        public static ObservableCollection<ClubsData> _clubListSource = new ObservableCollection<ClubsData>();
        public ObservableCollection<ClubsData> ClubListSource
        {
            get
            {
                return _clubListSource;
            }
        }

        public ClubsData _selectedItem { get; set; }
        public ClubsData SelectedItem
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

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        void OnTapped()
        {
            Application.Current.MainPage = new CustomNavigationPage(new MainPage());
        }

        public ClubVM ()
        {
        _clubListSource.Add(new ClubsData { ClubName = "BK Frem" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 2" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 3" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 4" });
        _clubListSource.Add(new ClubsData { ClubName = "Klub 5" });
            ContinueCommand = new Command(OnTapped);
        }  
    }
}
