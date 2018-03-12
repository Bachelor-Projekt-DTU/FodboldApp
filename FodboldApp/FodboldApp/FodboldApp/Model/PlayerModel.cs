using Realms;

namespace FodboldApp.Model
{
    public class PlayerModel : RealmObject
    {
        private string _name { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string ImageURL { get; set; }
        public string Sponsor { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public string Birthday { get; set; }
        public string Matches { get; set; }
        public string Wins { get; set; }
        public string Draws { get; set; }
        public string Losses { get; set; }
        public string Goals { get; set; }
        public string Assists { get; set; }
        public string MVP { get; set; }
        public string Clean_Sheet { get; set; }
        public int Index { get; set; }
        public string Position { get; set; }
        public string Debut { get; set; }
        public string Former_Clubs { get; set; }
        public string Description { get; set; }
        public string InternationalMatches { get; set; }
    }
}
