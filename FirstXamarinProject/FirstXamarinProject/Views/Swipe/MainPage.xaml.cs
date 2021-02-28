using FirstXamarinProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstXamarinProject.Views.Swipe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        bool isSwiping;
        public bool IsSwiping { get => isSwiping; set => isSwiping = value; }

        public MainPage()
        {
            InitializeComponent();
        }


        private async void SwipeGestureRecognizer_LeftSwiped(object sender, SwipedEventArgs e)
        {
            if (SwipeVM.CurrentFrame >= 0 && !IsSwiping)
            {
                IsSwiping = true;
                await Task.WhenAny<bool>(
                    absLayout.Children[SwipeVM.CurrentFrame].RotateTo(-30, 1000),
                    absLayout.Children[SwipeVM.CurrentFrame].TranslateTo(-600, -100, 1000)
                    );
                SwipeVM.CurrentFrame--;
                IsSwiping = false;
            }
        }

        private async void SwipeGestureRecognizer_RightSwiped(object sender, SwipedEventArgs e)
        {
            if (SwipeVM.CurrentFrame >= 0 && !IsSwiping)
            {
                IsSwiping = true;
                await Task.WhenAny<bool>(
                    absLayout.Children[SwipeVM.CurrentFrame].RotateTo(30, 1000),
                    absLayout.Children[SwipeVM.CurrentFrame].TranslateTo(600, -100, 1000)
                    );
                SwipeVM.CurrentFrame--;
                IsSwiping = false;
            }
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PanPage());
        }
    }
}