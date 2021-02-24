using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;
using Xamarin.Forms;

namespace FirstXamarinProject.ViewModels
{
    public class RegisterVM : INotifyPropertyChanged
    {
        string name;
        string surname;
        string password;
        string password2;
        string email;
        System.Drawing.Color bgColor;
        ImageSource image;
        ICommand imageSelectCommand;

        public string Name { get => name; set => name = value; }
        public string Surname { get => surname; set => surname = value; }
        public string Password { get => password; set => password = value; }
        public string Password2 { get => password2; set => password2 = value; }
        public string Email
        {
            get => email; set
            {
                if (email != value)
                {
                    email = value;
                    if (emailChecked(value))
                        BgColor = System.Drawing.Color.Transparent;
                    else
                        BgColor = System.Drawing.Color.IndianRed;
                }
            }
        }

        public System.Drawing.Color BgColor
        {
            get => bgColor; set
            {
                if (bgColor != value)
                {
                    bgColor = value;
                    OnPropertyChanged("BgColor");
                }
            }
        }

        public ICommand ImageSelectCommand { get => imageSelectCommand; set => imageSelectCommand = value; }
        public ImageSource Image { get => image; set => image = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterVM()
        {
            BgColor = System.Drawing.Color.Transparent;
            ImageSelectCommand = new Command(selectImage);
            Image = ImageSource.FromResource("FirstXamarinProject.Images.emptyUser.png");
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool emailChecked(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public async void selectImage()
        {
            var file = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions
            {
                PhotoSize = PhotoSize.Full
            });
            if (file != null)
            {
                Image = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
                OnPropertyChanged("Image");
            }
        }

    }
}
