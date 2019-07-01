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


using Android.Views.Animations;
using Android.Graphics;

namespace GNIBAndroid
{
    //[Activity(Label = "SplashActivity")]
    [Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]

    public class SplashActivity : Activity
    { 

        //protected override void OnCreate(Bundle bundle)
        //{
        //    base.OnCreate(bundle);

        //    // Set our view from the "main" layout resource
        //    SetContentView(Resource.Layout.Splash);
        //}
        //protected override void OnResume()
        //{
        //    base.OnResume();
        //    StartActivity(typeof(MainActivity));
        //}
        ImageView imageView;
        Animation splash_screen;
        TextView textview;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.Splash);

            imageView = (ImageView)FindViewById(Resource.Id.imageView1);
            textview = (TextView)FindViewById(Resource.Id.textView1);
            splash_screen = AnimationUtils.LoadAnimation(this, Resource.Animation.splash_screen);
            textview.SetTextColor(Color.Green);
            imageView.StartAnimation(splash_screen);
            splash_screen.AnimationEnd += Rotate_AnimationEnd;

        }

        private void Rotate_AnimationEnd(object sender, Animation.AnimationEndEventArgs e)
        {
            Finish();
            StartActivity(typeof(MainActivity));
        }
    }
}