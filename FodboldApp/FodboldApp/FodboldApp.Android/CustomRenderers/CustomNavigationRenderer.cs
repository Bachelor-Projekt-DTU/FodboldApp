using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace FodboldApp.Droid.CustomRenderers
{
    class CustomNavigationRenderer : NavigationRenderer
    {
        protected override Task<bool> OnPopViewAsync(Page page, bool animated)
        {
            return base.OnPopViewAsync(page, false);
        }

        protected override Task<bool> OnPushAsync(Page view, bool animated)
        {
            return base.OnPushAsync(view, false);
        }
    }
}