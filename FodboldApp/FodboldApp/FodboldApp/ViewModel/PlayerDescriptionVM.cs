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
            SetupDescription();
        }

        private void SetupDescription()
        {
            //Number = "01";
            //ImageURL = "http://www.bkfrem.dk/images/spillere/01_marco_brylov.jpg";
            //Name = Number + " " + "Marco Brylov";
            //Sponsor = "Carlsberg";
            //Position = "Målmand";
            //Height = "191cm";
            //Weight = "92kg";
            //Birthday = "21-11-1995";
            //Matches = "51 (7)";
            //Wins = "19";
            //Draws = "14";
            //Losses = "18";
            //Goals = "0 (0)";
            //Debut = "11. august 2015 ude i pokalkampen mod Ledøje-Smørum (4-6 e.str.)";
            //FormerClubs = "Ungdom: Hvidovre (fra sit 5. år til 2011) og FREM (2011-14) Senior: SC Egedal (foråret 2015 - 13 kampe) Tilbage til FREM fra efteråret 2015.";
            //Description = "Fulde navn: Marco Brylov. Født på Hvidovre Hospital. Opvokset i Hvidovre og har boet der lige siden.\nSom oprykket senior var målmandssituationen yderst hård i FREM med 3 gode målmænd, der på det tidspunkt stod foran Marco.\nDet var meningen, at Marco skulle udlånes til Fremad Valby, men han havnede i SC Egedal isf sammen med Jimmy Mayasi, for at udvikle sig og få noget kamp træning på et fornuftigt niveau.\nTrods god kritik i lokalpressen kunne Marco og hans holdkammerater ikke holde skansen i Danmarksserien og SC Egedal blev opløst som overbygning af Stenløse BK og FC Ølstykke og Marco valgte derfor at vende tilbage til FREM, hvor vejen til 1.holdet i mellemtiden var blevet kortere, da der nu kun var Simon Bloch Jørgensen tilbage, da de 2 andre konkurrenter var henholdsvis holdt op og skiftet klub.\nMarco vendte tilbage til Frem, da han har savnet klubben efter havde spillet der de sidste ungdomsår og som ung senior.";
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
