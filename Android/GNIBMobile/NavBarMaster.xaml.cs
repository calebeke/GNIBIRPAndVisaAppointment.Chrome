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

namespace GNIBMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavBarMaster : ContentPage
    {
        public ListView ListView;

        public NavBarMaster()
        {
            InitializeComponent();

            BindingContext = new NavBarMasterViewModel();
            ListView = MenuItemsListView;
        }

        class NavBarMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavBarMenuItem> MenuItems { get; set; }

            public NavBarMasterViewModel()
            {
                MenuItems = new ObservableCollection<NavBarMenuItem>(new[]
                {
                    new NavBarMenuItem { Id = 0, Title = "Page 1" },
                    new NavBarMenuItem { Id = 1, Title = "Page 2" },
                    new NavBarMenuItem { Id = 2, Title = "Page 3" },
                    new NavBarMenuItem { Id = 3, Title = "Page 4" },
                    new NavBarMenuItem { Id = 4, Title = "Page 5" },
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