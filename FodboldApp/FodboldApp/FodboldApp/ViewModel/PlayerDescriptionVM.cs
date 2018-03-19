using FodboldApp.Model;
using System.ComponentModel;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    class PlayerDescriptionVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Number { get { return ""/*Player.Name.Substring(0, 2)*/; } }
        public string ImageURL { get { return Player.ImageURL; } }
        public string Name { get { return Player.Name; } }
        public string Sponsor { get { return Player.Sponsor; } }
        public string Position { get { return Player.Position; } }
        public string Height { get { return Player.Height; } }
        public string Weight { get { return Player.Weight; } }
        public string Birthday { get { return Player.Birthday; } }
        public string Matches { get { return Player.Matches; } }
        public string Wins { get { return Player.Wins; } }
        public string Draws { get { return Player.Draws; } }
        public string Losses { get { return Player.Losses; } }
        public string Goals { get { return Player.Goals; } }
        public string Debut { get { return Player.Debut; } }
        public string FormerClubs { get { return Player.Former_Clubs; } }
        public string Description { get { return Player.Description; } }
        public int rowIndex = 3;

        //updates view when chosen player changes
        private PlayerModel _player { get; set; } = new PlayerModel();
        public PlayerModel Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = value;
                OnPropertyChanged(nameof(Player));
                OnPropertyChanged(nameof(Number));
                OnPropertyChanged(nameof(ImageURL));
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(Sponsor));
                OnPropertyChanged(nameof(Position));
                OnPropertyChanged(nameof(Height));
                OnPropertyChanged(nameof(Weight));
                OnPropertyChanged(nameof(Birthday));
                OnPropertyChanged(nameof(Matches));
                OnPropertyChanged(nameof(Wins));
                OnPropertyChanged(nameof(Draws));
                OnPropertyChanged(nameof(Losses));
                OnPropertyChanged(nameof(Goals));
                OnPropertyChanged(nameof(Debut));
                OnPropertyChanged(nameof(FormerClubs));
                OnPropertyChanged(nameof(Description));
            }
        }

        public PlayerDescriptionVM()
        {
        }
        
        public Color GetColor
        {
            get

            {
                return Globals.ColoringLogic.GetColor(rowIndex++ /3);
            }
        }
    }
}
