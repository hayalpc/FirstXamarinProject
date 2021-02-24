using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class AddCarVM : INotifyPropertyChanged
    {
        int id;
        string brand, model, details, year, imgUri;
        ImageSource imgSource;
        ICommand addCarCommand;
        ICommand backCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Details { get => details; set => details = value; }
        public string Year { get => year; set => year = value; }
        public ICommand AddCarCommand { get => addCarCommand; set => addCarCommand = value; }
        public ImageSource ImgSource { get => imgSource; set => imgSource = value; }
        public string ImgUri
        {
            get => imgUri; set
            {
                imgUri = value;
                try
                {
                    ImgSource = ImageSource.FromUri(new Uri(value));
                    OnPropertyChanged("ImgSource");
                }
                catch (Exception) { }
            }
        }

        public ICommand BackCommand { get => backCommand; set => backCommand = value; }

        public AddCarVM()
        {
            AddCarCommand = new Command(addCarFunction);
            BackCommand = new Command(backFunction);
        }

        async void addCarFunction()
        {
            var car = new Car()
            {
                Id = ListCreater.CarList.Last().Id + 1,
                Brand = this.Brand,
                Model = this.Model,
                Year = this.Year,
                ImgSource = ImageSource.FromUri(new Uri(this.ImgUri))
            };

            ListCreater.addCard(car);

            await App.Current.MainPage.Navigation.PopAsync();
            MessagingCenter.Send("AddPageSender", "EditMessage", "addRefresh");
        }

        async void backFunction()
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
