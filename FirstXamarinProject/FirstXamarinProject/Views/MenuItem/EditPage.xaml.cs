using FirstXamarinProject.Models;
using FirstXamarinProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.MenuItem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditPage : ContentPage
    {
        public EditPage(Car car)
        {
            InitializeComponent();
            BindingContext = new EditPageVM(car);
        }
    }
}