using Android.App;
using Android.Widget;
using Android.OS;

namespace GNIBMobile
{
    [Activity(Label = "GNIB/IRP", MainLauncher = false, Icon = "@drawable/irishLogo")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
             SetContentView (Resource.Layout.Main);
        }
    }
}

