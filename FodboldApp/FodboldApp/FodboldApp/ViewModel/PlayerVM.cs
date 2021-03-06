﻿using FodboldApp.Model;
using FodboldApp.Stack;
using FodboldApp.View;
using Realms;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerVM : INotifyPropertyChanged
    {
        Realm _realm;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand PlayerDescriptionCommand { get; private set; }

        private IQueryable<PlayerModel> _playerListSource { get; set; }
        public IQueryable<PlayerModel> PlayerListSource
        {
            get
            {
                return _playerListSource;
            }
            set
            {
                _playerListSource = value;
                OnPropertyChanged(nameof(PlayerListSource));
            }
        }

        private PlayerModel _selectedItem { get; set; }
        public PlayerModel SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public async void SetupRealm()
        {
            _realm = await NoInternetVM.IsConnectedOnMainPage("players");
            PlayerListSource = _realm.All<PlayerModel>().OrderBy(x => x.Number);
        }

        void OnTapped()
        {
            CustomStack.Instance.PlayerContent.Navigation.PushAsync(new PlayerDescription(SelectedItem));
            ViewModelLocator.HeaderVM.UpdateContent();
        }

        public PlayerVM()
        {
            SetupRealm();
            PlayerDescriptionCommand = new Command(OnTapped);
        }
    }
}
