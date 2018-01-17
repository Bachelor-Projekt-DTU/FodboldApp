using System;
using System.Collections.Generic;
using System.Text;

namespace FodboldApp.ViewModel
{
    static class ViewModelLocator
    {
        public static HeaderVM HeaderVM { get; } = new HeaderVM();
    }
}
