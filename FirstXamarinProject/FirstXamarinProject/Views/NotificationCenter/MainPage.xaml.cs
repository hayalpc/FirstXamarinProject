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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<SenderPage,Message>("Subscriber1","SenderPageMessage", messageFunction);

            //MessagingCenter.Unsubscribe<SenderPage, Message>("Subscriber1", "Message");
        }

        public void messageFunction(SenderPage sender,Message arg)
        {
            labelSender.Text = sender.Title;
            labelContent.Text = arg.Content;
            labelTopic.Text = arg.Topic;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SenderPage());
        }
    }
}