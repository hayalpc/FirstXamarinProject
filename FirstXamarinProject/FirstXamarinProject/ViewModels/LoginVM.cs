using FirstXamarinProject.Behaviours;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        string email, password;
        bool rememberMe;
        bool isRunning, layoutIsVisible;
        ICommand loginCommand;

        public string Email { get => email; set { email = value; OnPropertyChanged("Email"); } }
        public string Password { get => password; set { password = value; OnPropertyChanged("Password"); } }

        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }
        public bool RememberMe { get => rememberMe; set => rememberMe = value; }
        public bool IsRunning
        {
            get => isRunning; set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    LayoutIsVisible = !value;
                    OnPropertyChanged("IsRunning");
                }
            }
        }

        public bool LayoutIsVisible
        {
            get => layoutIsVisible; set
            {
                if (layoutIsVisible != value)
                {
                    layoutIsVisible = value;
                    OnPropertyChanged("LayoutIsVisible");
                }
            }
        }

        public LoginVM()
        {
            LoginCommand = new Command(LoginFunction);
            IsRunning = false;
            LayoutIsVisible = true;
        }

        async void LoginFunction()
        {
            IsRunning = true;
            Email = "eve.holt@reqres.in";
            Password = "cityslicka";
            if (Email.Length > 0 && Password?.Length > 6 && Regex.IsMatch(Email, EmailBehavior.emailRegex))
            {
                var loginResponse = UserService.Login(Email, Password);
                if (loginResponse.IsSuccess)
                {
                    IsRunning = false;
                    await App.Current.MainPage.DisplayAlert("Mesaj", "Giriş başarılı: " + loginResponse.Token, "Tamam");
                    App.Current.MainPage.Navigation.InsertPageBefore(new ProfilePage(), App.Current.MainPage.Navigation.NavigationStack.First());
                    await App.Current.MainPage.Navigation.PopToRootAsync();
                }
                else
                {
                    IsRunning = false;
                    await App.Current.MainPage.DisplayAlert("Hata!", "Giriş başarısız: " + loginResponse.Error, "Tamam");
                }
            }
            else
            {
                IsRunning = false;
                await App.Current.MainPage.DisplayAlert("Hata!", "Giriş bilgilerinizi kontrol ediniz!", "Tamam");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
