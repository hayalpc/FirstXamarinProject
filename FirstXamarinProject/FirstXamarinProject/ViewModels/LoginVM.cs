using FirstXamarinProject.Behaviours;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class LoginVM
    {
        string email, password;
        bool rememberMe;

        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }
        public bool RememberMe { get => rememberMe; set => rememberMe = value; }

        ICommand loginCommand;

        public LoginVM()
        {
            Email = "eve.holt@reqres.in";
            Password = "cityslicka";
            RememberMe = true;

            LoginCommand = new Command(LoginFunction);
        }

        async void LoginFunction()
        {
            if (Email.Length > 0 && Password?.Length > 6 && Regex.IsMatch(Email, EmailBehavior.emailRegex))
            {
                var loginResponse = UserService.Login(Email, Password);
                if (loginResponse.IsSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Mesaj", "Giriş başarılı: " + loginResponse.Token, "Tamam");
                    App.Current.MainPage.Navigation.InsertPageBefore(new ProfilePage(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Hata!", "Giriş başarısız: " + loginResponse.Error, "Tamam");
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Hata!", "Giriş bilgilerinizi kontrol ediniz!", "Tamam");
            }
        }
    }
}
