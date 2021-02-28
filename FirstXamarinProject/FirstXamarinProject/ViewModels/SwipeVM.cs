using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FirstXamarinProject.ViewModels
{
    public class SwipeVM : INotifyPropertyChanged
    {
        List<User> userList;
        int page = 1;
        static int currentFrame;

        public List<User> UserList
        {
            get => userList; set
            {
                if (userList != value)
                {
                    userList = value;
                    OnPropertyChanged("UserList");
                }
            }
        }

        public int Page { get => page; set => page = value; }
        public static int CurrentFrame { get => currentFrame; set => currentFrame = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public SwipeVM()
        {
            var userListRes = UserService.GetUsers(Page);
            if (userListRes.IsSuccess)
                UserList = userListRes.Data;

            CurrentFrame = UserList.Count - 1;
        }

    }
}
