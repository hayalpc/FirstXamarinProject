using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class VeriBaglama2 : INotifyPropertyChanged
    {
        int red, green, blue;
        Color color = Color.Black;

        public int Red
        {
            get => red; set
            {
                if (red != value)
                {
                    red = value;
                    OnPropertyChanged("Red");
                    setNewcolor();
                }
            }
        }
        public int Green
        {
            get => green; set
            {
                if (green != value)
                {
                    green = value;
                    OnPropertyChanged("Green");
                    setNewcolor();
                }
            }
        }
        public int Blue
        {
            get => blue; set
            {
                if (blue != value)
                {
                    blue = value;
                    OnPropertyChanged("Blue");
                    setNewcolor();
                }
            }
        }
        public Color Color
        {
            get => color; set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged("Color");
                    setNewcolor();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        void setNewcolor()
        {
            Color = Color.FromArgb(255, Red, Green, Blue);
        }
    }
}
