using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class PropertyChangedHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
