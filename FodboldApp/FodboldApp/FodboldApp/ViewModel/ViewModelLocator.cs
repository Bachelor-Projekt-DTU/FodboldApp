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
    }
}
