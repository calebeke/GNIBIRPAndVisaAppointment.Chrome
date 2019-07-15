﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GNIBMobile.Resources.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Hamburger : MasterDetailPage
    {
        HamburgerMaster masterPage;
        public Hamburger()
        {
            masterPage = new HamburgerMaster();
            Master = masterPage;
            Detail = new NavigationPage(new HamburgerDetail());
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as HamburgerMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            Detail = new NavigationPage(page);
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}