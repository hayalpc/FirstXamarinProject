using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class EditPageVM : INotifyPropertyChanged
    {
        Car selectedCar;
        string brand, model, details, year;
        ImageSource imgSource;
        ICommand saveCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public Car SelectedCar { get => selectedCar; set => selectedCar = value; }
        public string Brand
        {
            get => brand; set
            {
                if (brand != value)
                {
                    brand = value;
                }
            }
        }
        public string Model
        {
            get => model; set
            {
                if (model != value)
                {
                    model = value;
                }
            }
        }
        public string Details
        {
            get => details; set
            {
                if (details != value)
                {
                    details = value;
                }
            }
        }
        public string Year
        {
            get => year; set
            {
                if (year != value)
                {
                    year = value;
                }
            }
        }
        public ImageSource ImgSource { get => imgSource; set => imgSource = value; }
        public ICommand SaveCommand { get => saveCommand; set => saveCommand = value; }

        public EditPageVM()
        {

        }

        public EditPageVM(Car car)
        {
            SelectedCar = car;
            Brand = SelectedCar.Brand;
            Model = SelectedCar.Model;
            Details = SelectedCar.Details;
            Year = SelectedCar.Year;
            ImgSource = SelectedCar.ImgSource;
            SaveCommand = new Command(saveFunction);
        }

        async void saveFunction()
        {
            SelectedCar.Brand = Brand;
            SelectedCar.Model = Model;
            SelectedCar.Details = Details;
            SelectedCar.Year = Year;
            MessagingCenter.Send("EditPageSender","EditMessage", "refresh");
            await App.Current.MainPage.Navigation.PopAsync();
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
