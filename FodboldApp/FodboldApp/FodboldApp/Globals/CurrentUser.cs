using FodboldApp.Model;

namespace FodboldApp.Globals
{
    public static class CurrentUser
    {
        public static UserModel user = new UserModel();
        public static bool IsAdmin { get; set; } = false;
    }
}
