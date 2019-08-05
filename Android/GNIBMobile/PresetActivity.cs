using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace GNIBMobile
{
    [Activity(Label = "PresetFragment")]
    public class PresetActivity : Android.Support.V7.App.AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout./*PresetFragment*/ Splash);
        }
    }
}