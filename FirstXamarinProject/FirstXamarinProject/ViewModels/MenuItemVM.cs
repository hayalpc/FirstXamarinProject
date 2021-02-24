using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class MenuItemVM : ListViewVM
    {
        ICommand deleteCommand;
        ICommand editCommand;
        ICommand addCommand;

        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
        public ICommand AddCommand { get => addCommand; set => addCommand = value; }

        public MenuItemVM() : base()
        {
            DeleteCommand = new Command<Car>(deleteFuction);
            EditCommand = new Command<Car>(editFunction);
            AddCommand = new Command(addFunction);

            MessagingCenter.Subscribe<string, string>("MenuItemVM", "EditMessage", EditPageMessage);
        }

        async void EditPageMessage(string sender, string arg)
        {
            if (arg.Equals("refresh"))
            {
                refreshFunction();
                await App.Current.MainPage.DisplayAlert("Mesaj", "Düzenleme işlemi başarılır", "Tamam");
            }
            else if (arg.Equals("addRefresh"))
            {
                refreshFunction();
                await App.Current.MainPage.DisplayAlert("Mesaj", "Ekleme işlemi başarılır", "Tamam");
            }
        }

        public async void editFunction(Car car)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new EditPage(car)));
        }

        public void deleteFuction(Car car)
        {
            ListCreater.CarList.Remove(car);
            refreshFunction();
            App.Current.MainPage.DisplayAlert("Mesaj", $"{car.Brand} markalı {car.Model} model araç silinmiştir.", "Tamam");
        }

        public async void addFunction()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AddPage()));
        }
    }
}
