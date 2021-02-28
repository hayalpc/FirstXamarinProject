using FirstXamarinProject.Behaviours;
using FirstXamarinProject.Views.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace FirstXamarinProject.ViewModels.Firebase
{
    public class LoginVM : PropertyChangedHandler
    {
        string email, password;
        bool emailHasError, passwordHasError;
        bool isProcessing;

        ICommand loginCommand;
        public ICommand LoginCommand { get => loginCommand; set => loginCommand = value; }

        public string Email
        {
            get => email;
            set
            {
                if (email != value)
                {
                    email = value;
                    OnPropertyChanged("Email");
                }
            }
        }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public bool IsProcessing
        {
            get => isProcessing;
            set
            {
                isProcessing = value;
                OnPropertyChanged("IsButtonProcessing");
                OnPropertyChanged("IsProcessing");
            }
        }
        public bool IsButtonProcessing { get => !isProcessing; }

        public bool EmailHasError
        {
            get => emailHasError;
            set
            {
                emailHasError = value;
                OnPropertyChanged("EmailHasError");
            }
        }
        public bool PasswordHasError
        {
            get => passwordHasError;
            set
            {
                passwordHasError = value;
                OnPropertyChanged("PasswordHasError");
            }
        }

        public LoginVM()
        {
            LoginCommand = new Command(LoginFunction);
        }

        public async void LoginFunction()
        {
            EmailHasError = false;
            PasswordHasError = false;
            IsProcessing = true;
            if (Email == null || !Regex.IsMatch(Email, EmailBehavior.emailRegex))
            {
                IsProcessing = false;
                EmailHasError = true;
                await MaterialDialog.Instance.SnackbarAsync(message: "Lütfen e-posta adresini kontrol ediniz", msDuration: 3000, actionButtonText: "Tamam");
            }
            else
            {
                if (Password == null || Password.Length < 6)
                {
                    IsProcessing = false;
                    PasswordHasError = true;
                    await MaterialDialog.Instance.SnackbarAsync(message: "Şifreniz en az 6 karakter olmalıdır", msDuration: 3000, actionButtonText: "Tamam");
                }
                else
                {
                    var result = await App.FireBaseService.LoginWithEmailAndPasswordAsync(Email, Password);
                    if (result != null)
                    {
                        IsProcessing = false;
                        await MaterialDialog.Instance.SnackbarAsync("Oturum açma başarılıdır", 3000);
                        App.Current.MainPage.Navigation.InsertPageBefore(new ProfilePage(), App.Current.MainPage.Navigation.NavigationStack.Last());
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        EmailHasError = true;
                        PasswordHasError = true;
                        IsProcessing = false;
                        await MaterialDialog.Instance.SnackbarAsync(message: "Lütfen oturum açma bilginizi kontrol ediniz", msDuration: 5000, actionButtonText: "Tamam");
                    }
                }
            }

        }
    }
}
