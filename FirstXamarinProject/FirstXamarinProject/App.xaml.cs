using FirstXamarinProject.Helpers;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject
{
    public partial class App : Application
    {
        static FirebaseService fireBaseService;

        public static RestHelper RestHelper { get; set; }
        public static DbService DbService { get; set; }
        public static string UserToken { get; set; }
        public static Firebase.Auth.User User { get; set; }
        public static FirebaseService FireBaseService
        {
            get
            {
                if (fireBaseService == null)
                {
                    fireBaseService = new FirebaseService("AIzaSyDW_HKsIFGh4tLjJNZxu1lsZ3VdgUj9W_M");
                }
                return fireBaseService;
            }
            set { fireBaseService = value; }
        }

        public App()
        {
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            RestHelper = new RestHelper();
            DbService = new DbService(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "xamarinDB.db3"));
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
