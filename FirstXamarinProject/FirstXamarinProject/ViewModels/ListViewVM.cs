using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class ListViewVM : INotifyPropertyChanged
    {
        ObservableCollection<Car> carList;
        ICommand refreshCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Car> CarList
        {
            get => carList; set
            {
                carList = value;
                OnPropertyChanged("CarList");
            }
        }

        public ICommand RefreshCommand { get => refreshCommand; set => refreshCommand = value; }

        public ListViewVM()
        {
            refreshCommand = new Command(refreshFunction);
            CarList = new ObservableCollection<Car>(ListCreater.getCars());
        }

        public void refreshFunction()
        {
            CarList = new ObservableCollection<Car>(ListCreater.getCars());
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
