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

namespace GNIBMobile
{
    [Activity( MainLauncher = true, NoHistory = true)]
    public class Splash : Activity
    {
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
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Create your application here
        //}
    }
}