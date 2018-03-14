using FodboldApp.Globals;
using FodboldApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class ObservableCollectionsVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CommentModel TappedItem { get; set; }
        public ICommand DeleteCommentCommand { get; set; }
        public bool ListSwitch { get; set; }

        private IEnumerable<Object> _collectionList { get; set; }
        public IEnumerable<Object> CollectionList
        {
            get
            {
                return _collectionList;
            }
            set
            {
                _collectionList = value;
                OnPropertyChanged(nameof(CollectionList));
            }
        }

        async void DisplayDialog()
        {
            try
            {
                if (CurrentUser.IsAdmin || TappedItem.UserId == CurrentUser.user.Id)
                {
                    var answer = await Application.Current.MainPage.DisplayAlert("Slet kommentar", "Vil du gerne slette denne kommentar?", "Ja", "Nej");
                    if (answer == true)
                    {
                        MatchPageVM._realm.Write(() =>
                        {
                            MatchPageVM._realm.Remove(TappedItem);
                        });
                    }
                }
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Fejl", "Du kan ikke slette kommentaren på nuværende tidspunkt. Prøv igen senere", "Ok");
            }
        }

        void OnDeleteTapped()
        {
            Console.WriteLine("Tapped");
            DisplayDialog();
        }

        public ObservableCollectionsVM()
        {
            DeleteCommentCommand = new Command(OnDeleteTapped);
        }
    }
}
