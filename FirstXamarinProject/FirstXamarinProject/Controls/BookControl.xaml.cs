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
    public partial class BookControl : ContentView
    {
        public static BindableProperty NameTextProperty = BindableProperty.Create("NameText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, NameTextPropertyChanged);
        public static BindableProperty AuthorTextProperty = BindableProperty.Create("AuthorText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, AuthorTextPropertyChanged);
        public static BindableProperty CategoryTextProperty = BindableProperty.Create("CategoryText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, CategoryTextPropertyChanged);
        public static BindableProperty DescriptionTextProperty = BindableProperty.Create("DescriptionText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, DescriptionTextPropertyChanged);
        public static BindableProperty YearTextProperty = BindableProperty.Create("YearText", typeof(string), typeof(UserControl), string.Empty, BindingMode.TwoWay, null, YearTextPropertyChanged);
        public static BindableProperty ImgSourceProperty = BindableProperty.Create("ImgSource", typeof(ImageSource), typeof(UserControl), null, BindingMode.TwoWay, null, ImgSourcePropertyChanged);

        public string NameText
        {
            get { return GetValue(NameTextProperty).ToString(); }
            set { SetValue(NameTextProperty, value); }
        }
        public string AuthorText
        {
            get { return GetValue(AuthorTextProperty).ToString(); }
            set { SetValue(AuthorTextProperty, value); }
        }
        public string CategoryText
        {
            get { return GetValue(CategoryTextProperty).ToString(); }
            set { SetValue(CategoryTextProperty, value); }
        }
        public string DescriptionText
        {
            get { return GetValue(DescriptionTextProperty).ToString(); }
            set { SetValue(DescriptionTextProperty, value); }
        }
        public string YearText
        {
            get { return GetValue(YearTextProperty).ToString(); }
            set { SetValue(YearTextProperty, value); }
        }
        public ImageSource ImgSource
        {
            get { return GetValue(ImgSourceProperty) as ImageSource; }
            set { SetValue(ImgSourceProperty, value); }
        }

        public BookControl()
        {
            InitializeComponent();
        }

        private static void NameTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.labelName.Text = newValue.ToString();
        }

        private static void AuthorTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.labelAuthor.Text = newValue.ToString();
        }

        private static void CategoryTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.labelCategory.Text = newValue.ToString();
        }

        private static void DescriptionTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.labelDescription.Text = newValue.ToString();
        }

        private static void YearTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.labelYear.Text = newValue.ToString();
        }

        private static void ImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BookControl)bindable;
            control.image.Source = (ImageSource)newValue;
        }
    }
}