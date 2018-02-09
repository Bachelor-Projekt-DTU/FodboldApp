using System.Threading.Tasks;
using FodboldApp.Model;
using System.Net.Http;
using Newtonsoft.Json;

namespace FodboldApp.Services
{
    class FacebookService
    {
        public async Task<string> GetNameAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=name&access_token={accessToken}");
            var temp = JsonConvert.DeserializeObject<UserModel>(json);
            return temp.Name;
        }
        public async Task<Picture> GetPictureAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://graph.facebook.com/me?fields=picture&access_token={accessToken}");
            var temp = JsonConvert.DeserializeObject<FBUserModel>(json);
            return temp.Picture;
        }
    }
}
