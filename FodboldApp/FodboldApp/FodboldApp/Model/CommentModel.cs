using Realms;

namespace FodboldApp.Model
{
    class CommentModel : RealmObject
    {
        public string ImageURL { get; set; }
        public string UserName { get; set; }
        public string UserComment { get; set; }
        public string UserId { get; set; }
    }
}
