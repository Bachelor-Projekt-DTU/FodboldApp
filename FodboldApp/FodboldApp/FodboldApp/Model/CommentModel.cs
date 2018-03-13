using Realms;

namespace FodboldApp.Model
{
    public class CommentModel : RealmObject
    {
        public MatchModel Match { get; set; }
        public string ImageURL { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public string UserId { get; set; }
    }
}
