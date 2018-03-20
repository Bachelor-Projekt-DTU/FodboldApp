using Realms;

namespace FodboldApp.Model
{
    public class AdminModel: RealmObject
    {
        //used to create admins in realm, not used in app
        [PrimaryKey]
        public string UserId { get; set; }
    }
}
