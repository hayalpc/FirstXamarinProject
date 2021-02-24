using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class CarouselViewVM : INotifyPropertyChanged
    {
        private ObservableCollection<Car> carList;
        private Car selectedItem;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Car> CarList { get => carList; set => carList = value; }
        public Car SelectedItem { get => selectedItem; set
            {
                if(selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged("SelectedItem");
                }
            }
        }

        public CarouselViewVM()
        {
            CarList = new ObservableCollection<Car>(ListCreater.getCars());
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
