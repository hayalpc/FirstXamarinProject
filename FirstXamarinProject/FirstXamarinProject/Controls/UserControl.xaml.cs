using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserControl : ContentView
    {
        public static BindableProperty FullNameTextProperty = BindableProperty.Create("FullNameText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, FullNameTextPropertyChanged);
        public static BindableProperty FirstNameTextProperty = BindableProperty.Create("FirstNameText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, FirstNameTextPropertyChanged);
        public static BindableProperty LastNameTextProperty = BindableProperty.Create("LastNameText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, LastNameTextPropertyChanged);
        public static BindableProperty EmailTextProperty = BindableProperty.Create("EmailText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, EmailTextPropertyChanged);
        public static BindableProperty ImgSourceProperty = BindableProperty.Create("ImgSource", typeof(ImageSource), typeof(UserControl), null, BindingMode.TwoWay, null, ImgSourcePropertyChanged);

        public string FullNameText
        {
            get { return GetValue(FullNameTextProperty).ToString(); }
            set { SetValue(FullNameTextProperty, value); }
        }
        public string FirstNameText
        {
            get { return GetValue(FirstNameTextProperty).ToString(); }
            set { SetValue(FirstNameTextProperty, value); }
        }
        public string LastNameText
        {
            get { return GetValue(LastNameTextProperty).ToString(); }
            set { SetValue(LastNameTextProperty, value); }
        }
        public string EmailText
        {
            get { return GetValue(EmailTextProperty).ToString(); }
            set { SetValue(EmailTextProperty, value); }
        }
        public ImageSource ImgSource
        {
            get { return GetValue(ImgSourceProperty) as ImageSource; }
            set { SetValue(ImgSourceProperty, value); }
        }

        public UserControl()
        {
            InitializeComponent();
        }

        private static void FullNameTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (UserControl)bindable;
            control.labelFullName.Text = newValue.ToString();
        }

        private static void FirstNameTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }

        private static void LastNameTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
        private static void EmailTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (UserControl)bindable;
            control.labelEmail.Text = newValue.ToString();
        }

        private static void ImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (UserControl)bindable;
            control.image.Source = (ImageSource)newValue;
        }

    }
}