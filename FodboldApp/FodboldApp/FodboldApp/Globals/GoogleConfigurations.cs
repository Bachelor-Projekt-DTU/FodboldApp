namespace FodboldApp.Globals
{
    class GoogleConfigurations
    {
        // OAuth
        public static string iOSClientId = "274704195206-bplkrfn3b07bg7ruq56dss998m8me93k.apps.googleusercontent.com";
        public static string AndroidClientId = "274704195206-lhp82rg3vo8fivj5do0amtrurjtjdv2a.apps.googleusercontent.com";

        // OAuth parameters
        public static string Scope = "https://www.googleapis.com/auth/userinfo.profile";
        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";

        // RedirectURL (Reversed iOS/Android client ids)
        public static string iOSRedirectUrl = "com.googleusercontent.apps.274704195206-bplkrfn3b07bg7ruq56dss998m8me93k:/oauth2redirect";
        public static string AndroidRedirectUrl = "com.googleusercontent.apps.274704195206-lhp82rg3vo8fivj5do0amtrurjtjdv2a:/oauth2redirect";
    }
}
