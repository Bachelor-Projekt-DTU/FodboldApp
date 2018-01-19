using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp.Model
{
    class ObservableCollectionsModel
    {
        public ObservableCollection<Object> CollectionList { get; set; } = new ObservableCollection<Object>();
        public bool ListSwitch { get; set; }
    }
}
