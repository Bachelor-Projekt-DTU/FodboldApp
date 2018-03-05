using FodboldApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.ViewModel
{
    static class ViewModelLocator
    {
        public static HeaderVM HeaderVM { get; } = new HeaderVM();
        public static MatchHeaderVM MatchHeaderVM { get; } = new MatchHeaderVM();
        public static MatchPageVM MatchPageVM { get; } = new MatchPageVM();
        public static PlayerDescriptionVM PlayerDescriptionVM { get; } = new PlayerDescriptionVM();
        public static LoginVM LoginVM { get; } = new LoginVM();
        public static FacebookService FacebookService { get; } = new FacebookService();
        public static GoogleService GoogleService { get; } = new GoogleService();
        public static NoInternetVM NoInternetVM { get; } = new NoInternetVM();

    }
}
