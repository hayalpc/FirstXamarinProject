using FirstXamarinProject.Helpers;
using FirstXamarinProject.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject
{
    public partial class App : Application
    {
        public static RestHelper RestHelper { get; set; }

        public App()
        {
            InitializeComponent();
            RestHelper = new RestHelper();

            MainPage = new NavigationPage(new LoadingPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
