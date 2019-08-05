using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Runtime;
using Xamarin.Forms;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;

using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System;
using Xamarin.Forms.Platform.Android;
using ActionBar = Android.App.ActionBar;

namespace GNIBMobile
{
    [Activity(Label = "GNIB/IRP", MainLauncher = false, Icon = "@drawable/irishLogo", Theme ="@style/MyTheme")]

    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        DrawerLayout drawerLayout;
      private  NavigationView navigationView;
       
        Android.Support.V4.App.Fragment nativeFragment;

        public static MainActivity Instance;
        protected override void OnCreate(Bundle savedInstanceState)
{
            base.OnCreate(savedInstanceState);

            RequestWindowFeature(WindowFeatures.ActionBar);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);



            //SupportActionBar.SetDisplayShowTitleEnabled(false);
            //SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.menuIcon2);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.navigationView1);
            SetupDrawerContent(navigationView);




//        }if (_trackMapFragment == null)
//{
//    _trackMapFragment = new TrackMapFragment();
//        var fragmentTx = SupportFragmentManager.BeginTransaction();
//        fragmentTx.Add(Resource.Id.frame, _trackMapFragment);
//    fragmentTx.Commit();
}
       
        void SetupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) =>
            {
               

                //Add this
                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_appoint:
                        AddTab("New", new NewDateFrag());
                        AddTab("Renewal", new RenewDateFrag());

                        Toast.MakeText(this, "Action selected: Appoint" ,
    ToastLength.Short).Show();
                        break;
                    case Resource.Id.nav_cancel:
                        Toast.MakeText(this, "Action selected: " ,
    ToastLength.Short).Show();
                        break;
                    case Resource.Id.nav_preset:
                        Forms.Init(this, null);
                        nativeFragment = new DashFragment();
                        break;
                    case Resource.Id.nav_notify:
                        Toast.MakeText(this, "Action selected: ",
    ToastLength.Short).Show();
                        break;
                }
                SupportFragmentManager
      .BeginTransaction()
      .AddToBackStack(null)
      .Replace(Resource.Id.container, nativeFragment, "preset")
      .Commit();

                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch(item.ItemId)
           
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    break;

                //default:
                //   breaK;
                   
            }
                     //drawerLayout.CloseDrawers();      
                    return base.OnOptionsItemSelected(item);

            
        }

       
        void AddTab(string tabText, Android.Support.V4.App.Fragment fragment1)
        {
            var tab = this.ActionBar.NewTab();
            tab.SetText(tabText);
           
            // must set event handler for replacing tabs tab
            //tab.TabSelected += delegate (object sender, Android.App.ActionBar.TabEventArgs e) {
            //    e.FragmentTransaction.Replace(Resource.Id.container, fragment1);
            //};

            this.ActionBar.AddTab(tab);
        }



    }
}

