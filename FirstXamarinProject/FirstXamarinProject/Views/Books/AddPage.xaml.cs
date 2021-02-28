using FirstXamarinProject.Database;
using FirstXamarinProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.Books
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPage : ContentPage
    {
        public AddPage()
        {
            InitializeComponent();
            LoadComponents();
            BindingContext = new BookVM();
        }

        public AddPage(BookVM model)
        {
            InitializeComponent();
            LoadComponents();
            BindingContext = model;
        }

        public void LoadComponents()
        {
        }
    }
}