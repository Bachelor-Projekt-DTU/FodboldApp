﻿using FodboldApp.Services;

namespace FodboldApp.ViewModel
{
    //contains all ViewModels that require same instance for several views
    static class ViewModelLocator
    {
        public static MatchHeaderVM MatchHeaderVM { get; } = new MatchHeaderVM();
        public static HeaderVM HeaderVM { get; } = new HeaderVM();
        public static MatchPageVM MatchPageVM { get; } = new MatchPageVM();
        public static PlayerDescriptionVM PlayerDescriptionVM { get; } = new PlayerDescriptionVM();
        public static LoginVM LoginVM { get; } = new LoginVM();
        public static FacebookService FacebookService { get; } = new FacebookService();
        public static GoogleService GoogleService { get; } = new GoogleService();
        public static NoInternetVM NoInternetVM { get; } = new NoInternetVM();
        public static NewsPageVM NewsPageVM { get; } = new NewsPageVM();
        public static ChatVM ChatVM { get; } = new ChatVM();

    }
}
