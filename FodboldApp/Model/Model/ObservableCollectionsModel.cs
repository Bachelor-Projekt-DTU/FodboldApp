using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FodboldApp.Model
{
    public class ObservableCollectionsModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private IEnumerable<Object> _collectionList { get; set; }
        public IEnumerable<Object> CollectionList {
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
