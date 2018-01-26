using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace FodboldApp.Model
{
    public class ObservableCollectionsModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        private ObservableCollection<Object> _collectionList { get; set; }
        public ObservableCollection<Object> CollectionList {
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
        public bool ListSwitch { get; set; }
    }
}
