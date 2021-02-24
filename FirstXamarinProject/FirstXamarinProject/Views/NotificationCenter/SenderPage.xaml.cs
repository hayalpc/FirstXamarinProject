using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.NotificationCenter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SenderPage : ContentPage
    {
        public SenderPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var msg = new Message
            {
                Topic = entryTopic.Text,
                Content = entryContent.Text,
            };
            MessagingCenter.Send(this, "SenderPageMessage", msg);
            await Navigation.PopAsync();
        }
    }
}