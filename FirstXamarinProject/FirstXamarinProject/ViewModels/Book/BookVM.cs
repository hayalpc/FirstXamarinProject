using FirstXamarinProject.Extensions;
using FirstXamarinProject.ReqRes;
using FirstXamarinProject.Services;
using FirstXamarinProject.Views.Books;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class BookVM : INotifyPropertyChanged
    {
        int id;
        string name;
        string author;
        string description;
        string category;
        int year;
        int page;
        string image;
        DateTime createDate;
        DateTime updateDate;
        ImageSource imageSource;
        ICommand imageSelectCommand;
        ICommand addCommand;
        ICommand goToUpdateCommand; 

        public int Id { get => id; set => id = value; }
        public string Title { get => $"{Name} / {Author}";}
        public string Name { get => name; set => name = value; }
        public string Author { get => author; set => author = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public int Year { get => year; set => year = value; }
        public int Page { get => page; set => page = value; }
        public string Image { get => image; set => image = value; }
        public DateTime CreateDate { get => createDate; set => createDate = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }

        [JsonIgnore]
        public ImageSource ImageSource
        {
            get
            {
                if (imageSource == null && image == null)
                {
                    imageSource = ImageSource.FromResource("FirstXamarinProject.Images.noImage.png");
                }
                else if (imageSource == null && image != null)
                {
                    try
                    {
                        imageSource = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(Image)));
                    }
                    catch (Exception) { }
                }
                return imageSource;
            }
            set
            {
                if (imageSource != value)
                {
                    imageSource = value;
                    OnPropertyChanged("ImageSource");
                }
            }
        }

        [JsonIgnore]
        public ICommand ImageSelectCommand { get => imageSelectCommand; set => imageSelectCommand = value; }
        [JsonIgnore]
        public ICommand AddCommand { get => addCommand; set => addCommand = value; }
        [JsonIgnore]
        public ICommand GoToUpdateCommand { get => goToUpdateCommand; set => goToUpdateCommand = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public BookVM()
        {
            ImageSelectCommand = new Command(selectImage);
            GoToUpdateCommand = new Command(GoToUpdateFunction);
            AddCommand = new Command(AddFunction);
        }

        public async void GoToUpdateFunction()
        {
            await App.Current.MainPage.Navigation.PushAsync(new NavigationPage(new AddPage(this.Convert<BookVM>())));
        }

        public async void AddFunction()
        {
            DataResponse<BookVM> result;
            if (this.Id > 0)
            {
                result = BookService.Update(this);
            }
            else
            {
                result = BookService.Add(this);
            }
            if (result.IsSuccess)
            {
                MessagingCenter.Send("AddBook", "BookCommand", "refresh");
                await App.Current.MainPage.Navigation.PopAsync();
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", result.Error, "Tamam");
            }
        }

        public async void selectImage()
        {
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });
            if (file != null)
            {
                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        Image = Convert.ToBase64String(ms.ToArray());
                    }
                    stream.Position = 0;

                    return stream;
                });
            }
        }
    }
}
