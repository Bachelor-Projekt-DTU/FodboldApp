using FodboldApp.Model;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FodboldApp.Services
{
    class GoogleService
    {
        public async Task<string> GetNameAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://www.googleapis.com/userinfo/v2/me?fields=name&access_token={accessToken}");
            var temp = JsonConvert.DeserializeObject<UserModel>(json);
            return temp.Name;
        }
        public async Task<string> GetPictureAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://www.googleapis.com/userinfo/v2/me?fields=picture&access_token={accessToken}");
            var temp = JsonConvert.DeserializeObject<UserModel>(json);
            return temp.Picture;
        }
        public async Task<string> GetIdAsync(string accessToken)
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync($"https://www.googleapis.com/userinfo/v2/me?fields=id&access_token={accessToken}");
            var temp = JsonConvert.DeserializeObject<UserModel>(json);
            return temp.Id;
        }
    }
}
