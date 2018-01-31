using System.Threading.Tasks;
using FodboldApp.Model;
using System.Net.Http;
using Newtonsoft.Json;
using System;

namespace FodboldApp.Services
{
    class FacebookService
    {
        public async Task<UserModel> GetFacebookProfileAsync(string accessToken)
        {
            var requestUrl =
                "https://graph.facebook.com/v2.7/me/?fields=name,picture,website,link,devices,email&access_token="
                + accessToken;

            var httpClient = new HttpClient();

            var userJson = await httpClient.GetStringAsync(requestUrl);
            var facebookProfile = JsonConvert.DeserializeObject<UserModel>(userJson);

            return facebookProfile;
        }
    }
}
