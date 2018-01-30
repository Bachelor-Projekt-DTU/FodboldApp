using FodboldApp.Model;
using FodboldApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace FodboldApp.ViewModel
{
    class FacebookLoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private UserModel _facebookProfile;
        public UserModel FacebookProfile
        {
            get { return _facebookProfile; }
            set
            {
                _facebookProfile = value;
                OnPropertyChanged(nameof(FacebookProfile));
            }
        }

        public async Task SetFacebookUserProfileAsync(string accessToken)
        {
            var facebookService = new FacebookService();

            FacebookProfile = await facebookService.GetFacebookProfileAsync(accessToken);
            Console.WriteLine("feeeee" + FacebookProfile);
        }
    }
}
