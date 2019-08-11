using System;
using Android;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace NewGNIBMobile
{
    [Activity(Label = "GNIB/IRP", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
       /* Android.Support.V4.App.Fragment frag;*/ TabLayout tabLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
             tabLayout = (TabLayout)FindViewById(Resource.Id.tab_layout) ;
            SetSupportActionBar(toolbar);

            

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            NavigationView navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetNavigationItemSelectedListener(this);
          

           
        }

        

        //private void OnTabSelected(object sender, Android.App.ActionBar.TabEventArgs e)
        //{
        //    var CurrentTab = (Android.App.ActionBar.Tab)sender;

        //    if (CurrentTab.Position == 0)
        //    {
        //        e.FragmentTransaction.Replace(Resource.Id.container, new NewDFrag());
        //    }

        //    else
        //    {
        //        e.FragmentTransaction.Replace(Resource.Id.container, new RenewDFrag());
        //    }
        //}

        public override void OnBackPressed()
        {
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            if(drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        private void ReplaceFragment(Android.Support.V4.App.Fragment fragment)
        {
            SupportFragmentManager
             .BeginTransaction()
       .AddToBackStack(null)
       .Replace(Resource.Id.container, fragment)
       .Commit();
        }
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
           
            if (id == Resource.Id.nav_appoint)
            {
                // tabLayout.Visibility = ViewStates.Visible;

                tabLayout.AddTab(tabLayout.NewTab().SetText("New"));
                tabLayout.AddTab(tabLayout.NewTab().SetText("Renew"));
                ReplaceFragment(new NewDFrag());
            }
            else if (id == Resource.Id.nav_cancel)
            {

            }
            else if (id == Resource.Id.nav_preset)
            {
                
                Toast.MakeText(this, "Action selected: Appoint",
    ToastLength.Short).Show();
                ReplaceFragment(new PresetFrag()); 
            }
          
            else if (id == Resource.Id.nav_share)
            {

            }
            else if (id == Resource.Id.nav_send)
            {

            }
      
            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            
            return true;
        }

       
    }
}

