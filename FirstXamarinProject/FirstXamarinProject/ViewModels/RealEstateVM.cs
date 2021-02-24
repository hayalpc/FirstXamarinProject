using FirstXamarinProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class RealEstateVM
    {
        ObservableCollection<Features> features;
        public ObservableCollection<Features> Features { get => features; set => features = value; }


        public RealEstateVM()
        {
            Features = new ObservableCollection<Features>
            {
                new Features{Name="Metre Kare",Quantity="400"},
                new Features{Name="Oda Sayısı",Quantity="7"},
                new Features{Name="Banyo Sayısı",Quantity="2"},
                new Features{Name="Tuvalet Sayısı",Quantity="4"},
                new Features{Name="Garaj",Quantity="2"},
            };
        }

    }
}
