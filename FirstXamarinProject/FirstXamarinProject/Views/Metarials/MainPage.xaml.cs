using FirstXamarinProject.Behaviours;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace FirstXamarinProject.Views.Metarials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (tfPassword.Text.Length < 8)
                tfPassword.HasError = true;
            else
                tfPassword.HasError = false;

            if (!Regex.IsMatch(tfUsername.Text, EmailBehavior.emailRegex))
                tfUsername.HasError = true;
            else
                tfUsername.HasError = false;

            if (!tfPassword.HasError && !tfUsername.HasError)
            {
                await MaterialDialog.Instance.SnackbarAsync("Oturum açma başarılıdır", 3000);
            }
            else
            {
                await MaterialDialog.Instance.SnackbarAsync(message: "Lütfen oturum açma bilginizi kontrol ediniz", msDuration: 5000, actionButtonText: "Tamam");
            }
        }
    }
}