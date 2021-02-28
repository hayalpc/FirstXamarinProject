using FirstXamarinProject.Views.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Material.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace FirstXamarinProject.ViewModels.Firebase
{
    public class ProfileVM
    {
        ICommand logoutcommand;

        public string DisplayName { get; set; }
        public string Email { get; set; }
        public ICommand Logoutcommand { get => logoutcommand; set => logoutcommand = value; }

        public ProfileVM()
        {
            if (App.User == null)
            {
                MaterialDialog.Instance.SnackbarAsync("Giriş bilgileri geçersiz. Tekrar giriş yapınız", 5000);
                App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), App.Current.MainPage.Navigation.NavigationStack.Last());
                App.Current.MainPage.Navigation.PopAsync();
                return;
            }

            DisplayName = App.User.DisplayName;
            Email = App.User.Email;

            Logoutcommand = new Command(LogoutFunction);
        }

        public void LogoutFunction()
        {
            App.FireBaseService.Logout();
        }

    }
}
