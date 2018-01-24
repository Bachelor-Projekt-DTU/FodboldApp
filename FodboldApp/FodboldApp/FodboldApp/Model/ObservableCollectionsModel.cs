using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FodboldApp.Model
{
    class ObservableCollectionsModel
    {
        public IEnumerable<Object> CollectionList { get; set; } = new ObservableCollection<Object>();
        public bool ListSwitch { get; set; }
    }
}
