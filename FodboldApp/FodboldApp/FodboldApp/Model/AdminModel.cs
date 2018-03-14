using Realms;

namespace FodboldApp.Model
{
    public class AdminModel: RealmObject
    {
        [PrimaryKey]
        public string UserId { get; set; }
    }
}
