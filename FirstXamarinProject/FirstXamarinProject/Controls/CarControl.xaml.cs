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
    public partial class CarControl : ContentView
    {
        public static BindableProperty BrandTextProperty = BindableProperty.Create("BrandText", typeof(string), typeof(CarControl), string.Empty, BindingMode.TwoWay, null, BrandTextPropertyChanged);
        public static BindableProperty ModelTextProperty = BindableProperty.Create("ModelText", typeof(string), typeof(CarControl), string.Empty, BindingMode.TwoWay, null, ModelTextPropertyChanged);
        public static BindableProperty YearTextProperty = BindableProperty.Create("YearText", typeof(string), typeof(CarControl), string.Empty, BindingMode.TwoWay, null, YearTextPropertyChanged);
        public static BindableProperty DetailsTextProperty = BindableProperty.Create("DetailsText", typeof(string), typeof(CarControl), string.Empty, BindingMode.TwoWay, null, DetailsTextPropertyChanged);
        public static BindableProperty ImgSourceProperty = BindableProperty.Create("ImgSource", typeof(ImageSource), typeof(CarControl), null, BindingMode.TwoWay, null, ImgSourcePropertyChanged);

        public string BrandText
        {
            get { return GetValue(BrandTextProperty).ToString(); }
            set { SetValue(BrandTextProperty, value); }
        }
        public string ModelText
        {
            get { return GetValue(ModelTextProperty).ToString(); }
            set { SetValue(ModelTextProperty, value); }
        }
        public string YearText
        {
            get { return GetValue(YearTextProperty).ToString(); }
            set { SetValue(YearTextProperty, value); }
        }
        public string DetailsText
        {
            get { return GetValue(DetailsTextProperty).ToString(); }
            set { SetValue(DetailsTextProperty, value); }
        }

        public ImageSource ImgSource
        {
            get { return GetValue(ImgSourceProperty) as ImageSource; }
            set { SetValue(ImgSourceProperty, value); }
        }

        private static void BrandTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CarControl)bindable;
            control.labelBrand.Text = newValue.ToString();
        }
        private static void ModelTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CarControl)bindable;
            control.labelModel.Text = newValue.ToString();
        }
        private static void YearTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CarControl)bindable;
            control.labelYear.Text = newValue.ToString();
        }
        private static void DetailsTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CarControl)bindable;
            control.labelDetail.Text = newValue.ToString();
        }

        private static void ImgSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CarControl)bindable;
            control.image.Source = (ImageSource)newValue;
        }

        public CarControl()
        {
            InitializeComponent();
        }
    }
}