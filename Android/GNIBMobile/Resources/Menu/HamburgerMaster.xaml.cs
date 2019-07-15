using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GNIBMobile.Resources.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMaster : ContentPage
    {
        public ListView ListView { get { return listView; } }
        public ListView ListView;

        public HamburgerMaster()
        {
            InitializeComponent();

            BindingContext = new HamburgerMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HamburgerMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HamburgerMenuItem> MenuItems { get; set; }

            public HamburgerMasterViewModel()
            {
                MenuItems = new ObservableCollection<HamburgerMenuItem>(new[]
                {
                    new HamburgerMenuItem { Id = 0, Title = "Show Appointments" },
                    new HamburgerMenuItem { Id = 1, Title = "Book Appointment" },
                    new HamburgerMenuItem { Id = 2, Title = "Cancel Appointment" },
                    new HamburgerMenuItem { Id = 3, Title = "My Appointment" },
                   
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}