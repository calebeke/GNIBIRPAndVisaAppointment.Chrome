using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NewGNIBMobile
{
    public class PresetFrag : Android.Support.V4.App.Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
           
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            //if (container == null)
            //{
            //    return null;
            //}
            var view = inflater.Inflate(Resource.Layout.preset_form, container, false);
            return view;
            
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            Button btnsave = (Button) view.FindViewById(Resource.Id.saveBut);
            TextView tsample = (TextView)view.FindViewById(Resource.Id.sample);
            btnsave.Click += delegate {  tsample.Text="successful texting"; };
        }

        private void Save()
        {

           
        }

       
    }
}