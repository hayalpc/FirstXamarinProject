using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.Firebase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Register_Tapped(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new RegisterPage(), this);
            await Navigation.PopAsync();
        }
    }
}