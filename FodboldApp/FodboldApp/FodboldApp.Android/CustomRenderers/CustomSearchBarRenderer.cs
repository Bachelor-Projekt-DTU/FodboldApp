using Android.Content;
using Android.Widget;
using FodboldApp.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRendererAttribute(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace FodboldApp.Droid.CustomRenderers
{
    public class CustomSearchBarRenderer : SearchBarRenderer
    {
        public CustomSearchBarRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                LinearLayout linearLayout = Control.GetChildAt(0) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(2) as LinearLayout;
                linearLayout = linearLayout.GetChildAt(1) as LinearLayout;
                linearLayout.Background = null; //removes underline


                /*lort til at skifte searchicon til farven
                var searchView = Control;
                searchView.Iconified = true;
                searchView.SetIconifiedByDefault(false);
                // (Resource.Id.search_mag_icon); is wrong / Xammie bug
                int searchIconId = Context.Resources.GetIdentifier("android:id/search_mag_icon", null, null);
                var icon = searchView.FindViewById(searchIconId);

                (icon as ImageView).SetImageResource(Resource.Drawable.youriconforsearch);

                int cancelIconId = Context.Resources.GetIdentifier("android:id/search_close_btn", null, null);
                var eicon = searchView.FindViewById(cancelIconId);
                (eicon as ImageView).SetImageResource(Resource.Drawable.youriconforcancel);*/

                AutoCompleteTextView textView = linearLayout.GetChildAt(0) as AutoCompleteTextView; //modify for text appearance customization 
            }
        }
    }
}