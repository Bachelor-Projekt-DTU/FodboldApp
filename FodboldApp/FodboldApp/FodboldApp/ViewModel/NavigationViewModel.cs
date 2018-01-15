using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class NavigationViewModel : INotifyPropertyChanged
    {
        int taps = 0;
        ICommand tapCommand;
        public NavigationViewModel()
        {
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
        }
        public ICommand TapCommand
        {
            get { return tapCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnTapped(object s)
        {
            taps++;
            Debug.WriteLine("parameter: " + s);
        }
    }
}
