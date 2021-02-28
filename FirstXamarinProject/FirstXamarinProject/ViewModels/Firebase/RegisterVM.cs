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
    public class RegisterVM : PropertyChangedHandler
    {
        string name, surname, email, password, passwordAgain;
        bool nameHasError, surnameHasError, emailHasError, passwordHasError, passwordAgainHasError;
        ICommand registerCommand;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string PasswordAgain { get => passwordAgain; set => passwordAgain = value; }
        public ICommand RegisterCommand { get => registerCommand; set => registerCommand = value; }

        public bool NameHasError
        {
            get => nameHasError;
            set
            {
                if (nameHasError != value)
                {
                    nameHasError = value;
                    OnPropertyChanged("NameHasError");
                }
            }
        }
        public bool SurnameHasError
        {
            get => surnameHasError;
            set
            {
                surnameHasError = value;
                OnPropertyChanged("SurnameHasError");
            }
        }
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
        public bool PasswordAgainHasError
        {
            get => passwordAgainHasError;
            set
            {
                passwordAgainHasError = value;
                OnPropertyChanged("PasswordAgainHasError");
            }
        }

        public RegisterVM()
        {
            RegisterCommand = new Command(RegisterFunction);
        }

        public async void RegisterFunction()
        {
            EmailHasError = false;
            NameHasError = false;
            SurnameHasError = false;
            PasswordHasError = false;
            PasswordAgainHasError = false;

            if (Email == null || !Regex.IsMatch(Email, EmailBehavior.emailRegex))
            {
                EmailHasError = true;
                await MaterialDialog.Instance.SnackbarAsync(message: "Lütfen e-posta adresini kontrol ediniz", msDuration: 3000, actionButtonText: "Tamam");
            }
            else
            {
                if (Name == null || Surname == null || (Name.Length < 2 && Surname.Length < 2))
                {
                    NameHasError = true;
                    SurnameHasError = true;
                    await MaterialDialog.Instance.SnackbarAsync(message: "Lütfen adınızı ve soyadınızı kontrol ediniz", msDuration: 3000, actionButtonText: "Tamam");
                }
                else
                {
                    if (Password == null || Password.Length < 6)
                    {
                        PasswordHasError = true;
                        await MaterialDialog.Instance.SnackbarAsync(message: "Şifreniz en az 6 karakter olmalıdır", msDuration: 3000, actionButtonText: "Tamam");
                    }
                    else
                    {
                        if (PasswordAgain == null || Password != PasswordAgain)
                        {
                            PasswordHasError = true;
                            PasswordAgainHasError = true;
                            await MaterialDialog.Instance.SnackbarAsync(message: "Şifreleriniz uyuşmuyor. Lütfen şifreleri kontrol ediniz", msDuration: 3000, actionButtonText: "Tamam");
                        }
                        else
                        {
                            var result = await App.FireBaseService.RegisterWithEmailAndPasswordAsync(Name, Surname, Email, Password);
                            if (result != null)
                            {
                                await MaterialDialog.Instance.SnackbarAsync("Kayıt olma başarılıdır", 3000);
                                App.Current.MainPage.Navigation.InsertPageBefore(new ProfilePage(), App.Current.MainPage.Navigation.NavigationStack.Last());
                                await App.Current.MainPage.Navigation.PopAsync();
                            }
                            else
                            {
                                EmailHasError = true;
                                PasswordHasError = true;
                                await MaterialDialog.Instance.SnackbarAsync(message: "Kayıt olunamadı. Lütfen bilginizi kontrol ediniz", msDuration: 5000, actionButtonText: "Tamam");
                            }
                        }
                    }
                }
            }
        }
    }
}
