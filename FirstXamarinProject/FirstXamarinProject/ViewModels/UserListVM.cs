using FirstXamarinProject.Models;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class UserListVM : INotifyPropertyChanged
    {
        int page = 1;
        bool isRefresing;

        ObservableCollection<User> userList;
        ICommand deleteCommand;
        ICommand editCommand;
        ICommand addCommand;
        ICommand refreshCommand;
        ICommand loadMoreCommand;

        public ICommand DeleteCommand { get => deleteCommand; set => deleteCommand = value; }
        public ICommand EditCommand { get => editCommand; set => editCommand = value; }
        public ICommand AddCommand { get => addCommand; set => addCommand = value; }
        public ICommand RefreshCommand { get => refreshCommand; set => refreshCommand = value; }
        public ICommand LoadMoreCommand { get => loadMoreCommand; set => loadMoreCommand = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<User> UserList
        {
            get => userList; set
            {
                userList = value;
                OnPropertyChanged("UserList");
            }
        }

        public int Page { get => page; set => page = value; }
        public bool IsRefresing { get => isRefresing; set
            {
                if(isRefresing != value)
                {
                    isRefresing = value;
                    OnPropertyChanged("IsRefresing");
                }
            }
        }

        public UserListVM()
        {
            DeleteCommand = new Command<User>(deleteFuction);
            EditCommand = new Command<User>(editFunction);
            AddCommand = new Command(addFunction);
            RefreshCommand = new Command(refreshFunction);
            LoadMoreCommand = new Command(loadMoreFunction);

            loadUsers();
        }

        public void loadUsers()
        {
            var userRes = UserService.GetUsers(Page);
            if (userRes.IsSuccess)
            {
                if (Page > 1)
                {
                    var newList = UserList.ToList();
                    newList.AddRange(userRes.Data);
                    UserList = new ObservableCollection<User>(newList);
                }
                else
                    UserList = new ObservableCollection<User>(userRes.Data);
            }
        }

        public void loadMoreFunction()
        {
            Page++;
            loadUsers();
        }

        public async void refreshFunction()
        {
            await Task.Run(() => {
                IsRefresing = true;
                Page = 1;
                loadUsers();
                IsRefresing = false;
            });
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void editFunction(User car)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new RegisterPage()));
        }

        public void deleteFuction(User car)
        {
            loadUsers();
            App.Current.MainPage.DisplayAlert("Mesaj", $"{car.Id} ID'li {car.Full_name} isimli kullanıcı silinmiştir.", "Tamam");
        }

        public async void addFunction()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new RegisterPage()));
        }
    }
}
