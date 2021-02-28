using Firebase.Auth;
using FirstXamarinProject.Views.Firebase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FirstXamarinProject.Services
{
    public class FirebaseService
    {
        FirebaseAuthProvider authProvider;

        public FirebaseService(string apiKey = null)
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(apiKey != null ? apiKey : "AIzaSyDW_HKsIFGh4tLjJNZxu1lsZ3VdgUj9W_M"));
        }

        public async Task<FirebaseAuthLink> LoginWithEmailAndPasswordAsync(string email, string password)
        {
            try
            {
                var fal = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
                await SecureStorage.SetAsync("userToken", fal.FirebaseToken);
                App.UserToken = fal.FirebaseToken;
                App.User = fal.User;
                return fal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<FirebaseAuthLink> RegisterWithEmailAndPasswordAsync(string name, string surname, string email, string password)
        {
            try
            {
                var fal = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, $"{name} {surname}");
                await SecureStorage.SetAsync("userToken", fal.FirebaseToken);
                App.UserToken = fal.FirebaseToken;
                App.User = fal.User;
                return fal;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> LoginWithToken()
        {
            try
            {
                if (App.UserToken == null && App.User == null)
                {
                    var tokenVal = await SecureStorage.GetAsync("userToken");
                    if (tokenVal != null)
                    {
                        var user = await authProvider.GetUserAsync(tokenVal);
                        App.UserToken = tokenVal;
                        App.User = user;
                        return true;
                    }
                    else
                        return false;
                }
                else
                    return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CheckToken()
        {
            if (App.UserToken == null && App.User == null)
            {
                await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            else
            {
                var result = await App.FireBaseService.LoginWithToken();
                if (result)
                    await App.Current.MainPage.Navigation.PushAsync(new ProfilePage());
                else
                    await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            }
            return true;
        }

        public void Logout()
        {
            try
            {
                if (App.UserToken != null)
                    SecureStorage.Remove(App.UserToken);
                App.User = null;
                App.UserToken = null;
                App.Current.MainPage.Navigation.InsertPageBefore(new Views.SplashScreen(CheckToken),App.Current.MainPage.Navigation.NavigationStack.Last());
                App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception exp) {
                Console.WriteLine(exp.Message);
            }
        }

    }
}
