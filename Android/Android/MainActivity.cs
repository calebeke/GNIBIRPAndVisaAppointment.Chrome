﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace Android
{
    [Activity(Label = "GNIB/IRP", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main"  resource
            SetContentView (Resource.Layout.Main);
        }
    }
}

