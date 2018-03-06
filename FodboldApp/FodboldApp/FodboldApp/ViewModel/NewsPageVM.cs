using FodboldApp.Model;
using Plugin.Share;
using Plugin.Share.Abstractions;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FodboldApp.ViewModel
{
    public class NewsPageVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private NewsModel _newsModel { get; set; } = new NewsModel();
        public NewsModel NewsModel
        {
            get
            {
                return _newsModel;
            }
            set
            {
                _newsModel = value;
                OnPropertyChanged(nameof(NewsModel));
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(DateTime));
                OnPropertyChanged(nameof(SmallText));
                OnPropertyChanged(nameof(ImageURL));
                OnPropertyChanged(nameof(NewsText));
            }
        }
        public ICommand ShareCommand { get; set; }
        public string Title { get { return NewsModel.Title; } }
        public string DateTime { get { return NewsModel.Date; } }
        public string SmallText { get { return NewsModel.SmallText; } }
        public string ImageURL { get { return NewsModel.ImageURL; } }
        public string NewsText { get { return NewsModel.Text; } }

        private void OnShareTapped()
        {
            if (!CrossShare.IsSupported)
                return;

            CrossShare.Current.Share(new ShareMessage
            {
                Url = "http://www.bkfrem.dk/default.asp?vis=nyheder&id=" + NewsModel.ArticleId
            });
        }

        public NewsPageVM()
        {
            ShareCommand = new Command(OnShareTapped);
        }

       
    }
}
