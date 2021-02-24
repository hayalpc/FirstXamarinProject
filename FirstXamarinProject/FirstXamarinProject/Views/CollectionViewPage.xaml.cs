using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CollectionViewPage : ContentPage
    {
        public CollectionViewPage()
        {
            InitializeComponent();
        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Car car = ((CollectionView)sender).SelectedItem as Car;
            if (car == null)
                return;
            else
                await Navigation.PushAsync(new DetailPage(car));
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var car = ((TappedEventArgs)e).Parameter as Car;
            if (car == null)
                return;
            else
                await Navigation.PushAsync(new DetailPage(car));
        }
    }
}