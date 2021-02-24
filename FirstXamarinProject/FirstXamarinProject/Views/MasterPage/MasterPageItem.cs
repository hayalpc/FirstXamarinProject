using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FirstXamarinProject.Views.MasterPage
{
    public class MasterPageItem
    {
        string title, detail;
        ImageSource icon;
        Type targetType;

        public string Title { get => title; set => title = value; }
        public string Detail { get => detail; set => detail = value; }
        public ImageSource Icon { get => icon; set => icon = value; }
        public Type TargetType { get => targetType; set => targetType = value; }
    }
}
