using System;
using System.Collections.Generic;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class SettingVM
    {
        string userName,address,fullName;
        bool notifications;
        int brightness;

        public string UserName { get => userName; set => userName = value; }
        public string Address { get => address; set => address = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public bool Notifications { get => notifications; set => notifications = value; }
        public int Brightness { get => brightness; set => brightness = value; }

        public SettingVM()
        {
            UserName = "XamarinTableView";
            Notifications = false;
            Address = "Turkey";
            FullName = "Xamarin Demo";
            Brightness = 125;
        }
    }
}
