using FirstXamarinProject.Services;
using FirstXamarinProject.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class ProfileVM
    {
        int id;
        string email, first_name, last_name;
        ImageSource avatar;

        public int Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string First_name { get => first_name; set => first_name = value; }
        public string Last_name { get => last_name; set => last_name = value; }
        public ImageSource Avatar { get => avatar; set => avatar = value; }
        
        public string Full_name { get { return first_name + " " + last_name; } }

        public ProfileVM()
        {
            var profile = UserService.GetUser(new Random().Next(1, 6));
            if (profile.IsSuccess)
            {
                this.Id = profile.Data.Id;
                this.Email = profile.Data.Email;
                this.First_name = profile.Data.First_name;
                this.Last_name = profile.Data.Last_name;
                this.Avatar = ImageSource.FromUri(new Uri(profile.Data.Avatar));
            }
            else
            {
                App.Current.MainPage.Navigation.InsertPageBefore(new LoginPage(), App.Current.MainPage.Navigation.NavigationStack.First());
                App.Current.MainPage.Navigation.PopToRootAsync();
            }
        }
    }
}
