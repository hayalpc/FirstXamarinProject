using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.MasterPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();
            profileImage.Source = ImageSource.FromUri(new Uri("https://media-exp1.licdn.com/dms/image/C5603AQFxxuYmmjBzdA/profile-displayphoto-shrink_200_200/0/1517404403253?e=1619654400&v=beta&t=I4n1xlB3m8mKk5PBtRlnsnGRmgV251bqDpguwbd0RyY"));
            menuList.ItemsSource = getMenuList();
            IsPresented = false;
        }

        private void menuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterPageItem)e.SelectedItem;
            var selectedPage = selectedMenuItem.TargetType;
            Detail = new NavigationPage((Page)Activator.CreateInstance(selectedPage));
            IsPresented = false;
        }

        public List<MasterPageItem> getMenuList()
        {
            var list = new List<MasterPageItem>();

            list.Add(new MasterPageItem()
            {
                Title = "Cars",
                Icon = ImageSource.FromResource("FirstXamarinProject.Images.carIcon.png"),
                TargetType = typeof(CarsPage),
                Detail = "Cars Page"
            });

            list.Add(new MasterPageItem()
            {
                Title = "Contacts",
                Icon = ImageSource.FromResource("FirstXamarinProject.Images.contacts.png"),
                TargetType = typeof(ContactPage),
                Detail = "Contact Us"
            });

            list.Add(new MasterPageItem()
            {
                Title = "Settings",
                Icon = ImageSource.FromResource("FirstXamarinProject.Images.settings.png"),
                TargetType = typeof(SettingsPage),
                Detail = "Settings Page"
            });

            return list;
        }
    }
}