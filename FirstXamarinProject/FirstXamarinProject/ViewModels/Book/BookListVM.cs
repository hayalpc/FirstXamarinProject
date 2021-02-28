using FirstXamarinProject.Database;
using FirstXamarinProject.Extensions;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views.Books;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class BookListVM : INotifyPropertyChanged
    {

        int page = 0;
        bool isRefresing;

        ObservableCollection<BookVM> bookList;
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
        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<BookVM> BookList
        {
            get => bookList; set
            {
                bookList = value;
                OnPropertyChanged("BookList");
            }
        }

        public int Page { get => page; set => page = value; }
        public bool IsRefresing
        {
            get => isRefresing; set
            {
                if (isRefresing != value)
                {
                    isRefresing = value;
                    OnPropertyChanged("IsRefresing");
                }
            }
        }


        public BookListVM()
        {
            DeleteCommand = new Command<BookVM>(DeleteFunction);
            EditCommand = new Command<BookVM>(EditFunction);
            AddCommand = new Command(AddFunction);
            RefreshCommand = new Command(RefreshFunction);
            LoadMoreCommand = new Command(LoadMoreFunction);

            LoadBooks();
            MessagingCenter.Subscribe<string, string>("BookListSubscriber", "BookCommand", BookCommandMessage);
        }

        void BookCommandMessage(string sender, string arg)
        {
            if (arg.Equals("refresh"))
            {
                RefreshFunction();
            }
        }

        public void LoadBooks()
        {
            var service = BookService.GetList(Page);
            if (service.IsSuccess)
            {
                if (Page > 0)
                {
                    if (service.Data.Count > 0)
                    {
                        var newList = BookList.ToList();
                        newList.AddRange(service.Data);
                        BookList = new ObservableCollection<BookVM>(newList);
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Uyarı", $"Kayıt sonuna gelinmiştir.", "Tamam");
                    }
                }
                else
                    BookList = new ObservableCollection<BookVM>(service.Data);
            }
        }

        public void LoadMoreFunction()
        {
            Page++;
            LoadBooks();
        }

        public void RefreshFunction()
        {
            IsRefresing = true;
            LoadBooks();
            IsRefresing = false;
        }

        public async void EditFunction(BookVM model)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AddPage(model.Convert<BookVM>())));
        }

        public void DeleteFunction(BookVM model)
        {
            BookService.Delete(model.Id);
            RefreshFunction();
            App.Current.MainPage.DisplayAlert("Mesaj", $"{model.Id} ID'li kayıt silinmiştir.", "Tamam");
        }

        public async void AddFunction()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AddPage()));
        }

    }
}
