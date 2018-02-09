namespace FodboldApp.Globals
{
    public class test
    {
        public test(
            string clientId,
            string scope,
            string authorizeUrl,
            string accessTokenUrl,
            string redirectUrl)
        {
            ClientId = clientId;
            Scope = scope;
            AuthorizeUrl = authorizeUrl;
            RedirectUrl = redirectUrl;
            AccessTokenUrl = accessTokenUrl;
        }

        public string ClientId { get; private set; }
        public string Scope { get; private set; }
        public string AuthorizeUrl { get; private set; }
        public string RedirectUrl { get; private set; }
        public string AccessTokenUrl { get; private set; }
    }
}
