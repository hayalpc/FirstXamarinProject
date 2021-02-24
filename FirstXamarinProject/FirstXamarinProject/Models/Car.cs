using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.Models
{
    public class Car
    {
        int id;
        string brand, model, details, year;
        ImageSource imgSource;

        public int Id { get => id; set => id = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public string Details { get => details; set => details = value; }
        public string Year { get => year; set => year = value; }
        public ImageSource ImgSource { get => imgSource; set => imgSource = value; }

        public string PageTitle
        {
            get
            {
                return $"{Brand} - {Model}({Year})";
            }
        }

    }
}
