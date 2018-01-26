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
    class ClubVM : ClubModel
    {
        public ICommand ContinueCommand { get; set; }
        public static ObservableCollection<ClubModel> _clubListSource = new ObservableCollection<ClubModel>();
        public ObservableCollection<ClubModel> ClubListSource
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
                    if (_selectedItem != null)
                        _selectedItem.Selected = false;

                    _selectedItem = value;

                    if (_selectedItem != null)
                        _selectedItem.Selected = true;

                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        void ContinueOnTapped()
        {
            Application.Current.MainPage = new CustomNavigationPage(new MainPage());
        }

        public ClubVM()
        {
            _clubListSource.Add(new ClubModel { ClubName = "BK Frem" });
            _clubListSource.Add(new ClubModel { ClubName = "Klub 2" });
            _clubListSource.Add(new ClubModel { ClubName = "Klub 3" });
            _clubListSource.Add(new ClubModel { ClubName = "Klub 4" });
            _clubListSource.Add(new ClubModel { ClubName = "Klub 5" });
            ContinueCommand = new Command(ContinueOnTapped);
        }
    }
}
