using FirstXamarinProject.Models;
using FirstXamarinProject.ViewModels;
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
    public partial class DetailPage : ContentPage
    {
        public DetailPage(Car car)
        {
            InitializeComponent();

            image.BackgroundColor = Color.Transparent;
            model.BackgroundColor = Color.Transparent;
            year.BackgroundColor = Color.Transparent;
            details.BackgroundColor = Color.Transparent;

            BindingContext = new DetailVM(car);
        }
    }
}