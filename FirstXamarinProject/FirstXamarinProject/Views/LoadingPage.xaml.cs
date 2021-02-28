using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using FirstXamarinProject.Views.MasterPage;
using Xamarin.Forms.Xaml;
using FirstXamarinProject.Services;

namespace FirstXamarinProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage());
        }
        private async void RegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
        private async void VeriBaglama2Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VeriBaglama2Page());
        }
        private async void ListViewClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new ListViewPage(), this);
            await Navigation.PopAsync();
        }
        private async void CollectionViewClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new CollectionViewPage(), this);
            await Navigation.PopAsync();
        }
        private async void TableViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TableViewPage());
        }
        private async void CarouselViewClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CarouselViewPage());
        }
       
        private async void MasterPageClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MasterPage.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void TabbedPageClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new TabPage.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void RealEstatePageClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RealEstate.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void MenuItemPageClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new MenuItem.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void CustomControlClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new CustomControl.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void MetarialClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new Metarials.MainPage(), this);
            await Navigation.PopAsync();
        }
        private async void FirebaseClicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new SplashScreen(App.FireBaseService.CheckToken), this);
            await Navigation.PopAsync();
        }
        private async void NotificationCenterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NotificationCenter.MainPage());
        }
        private async void BookClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Books.ListPage());
        }
        private async void BehaviorsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Behaviors.MainPage());
        }
        private async void UserListClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserListPage());
        }
        private async void SwipeClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Swipe.MainPage());
        }
        //private void userName_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var entry = (Entry)sender;
        //    try
        //    {
        //        var usernameText = entry.Text;
        //        var passwordText = password.Text;
        //        if(usernameText.Length > 6 && passwordText.Length > 6)
        //            loginBtn.IsEnabled = true;
        //        else
        //            loginBtn.IsEnabled = false;
        //    }
        //    catch(Exception exp)
        //    {
        //        Console.WriteLine($"Exception: {exp}");
        //    }
        //}

        //private void password_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    var entry = (Entry)sender;
        //    try
        //    {
        //        var usernameText = userName.Text;
        //        var passwordText = entry.Text;
        //        if(usernameText.Length > 6 && passwordText.Length > 6)
        //            loginBtn.IsEnabled = true;
        //        else
        //            loginBtn.IsEnabled = false;
        //    }
        //    catch(Exception exp)
        //    {
        //        Console.WriteLine($"Exception: {exp}");
        //    }
        //}
    }
}
