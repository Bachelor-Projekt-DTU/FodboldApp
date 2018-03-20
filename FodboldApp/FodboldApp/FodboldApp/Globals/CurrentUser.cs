using FodboldApp.Model;

namespace FodboldApp.Globals
{
    public static class CurrentUser
    {
        //saves current user info for log ins
        public static UserModel user = new UserModel();
        public static bool IsAdmin { get; set; } = false;
    }
}
