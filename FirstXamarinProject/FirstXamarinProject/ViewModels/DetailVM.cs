using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class DetailVM
    {
        private Car car;
        public Car Car { get => car; set => car = value; }

        public DetailVM(Car car)
        {
            this.Car = car;
        }

    }
}
