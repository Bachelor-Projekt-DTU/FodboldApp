using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class MatchesVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private IQueryable<MatchModel> _matchList { get; set; }
        public IQueryable<MatchModel> MatchList
        {

            get
            {
                return _matchList;
            }
            private set
            {
                _matchList = value;
                OnPropertyChanged(nameof(MatchList));
            }
        }

        private MatchModel _selectedItem { get; set; }
        public MatchModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
            }
        }
        public ICommand MatchTapped { get; private set; }

        //loads previous matches
        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("matches");
            MatchList = _realm.All<MatchModel>();
        }

        public void MatchTap()
        {
            CustomStack.Instance.MatchContent.Navigation.PushAsync(new MatchPage(SelectedItem));
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public MatchesVM()
        {
            SetupRealm();
            MatchTapped = new Command(MatchTap);
        }
    }
}
