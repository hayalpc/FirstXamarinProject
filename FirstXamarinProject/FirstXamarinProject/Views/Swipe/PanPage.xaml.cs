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
    public partial class PanPage : ContentPage
    {
        bool isSwiping;

        public bool IsSwiping { get => isSwiping; set => isSwiping = value; }

        public PanPage()
        {
            InitializeComponent();
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (SwipeVM.CurrentFrame >= 0)
            {
                View currentFrame = absLayout.Children[SwipeVM.CurrentFrame];
                switch (e.StatusType)
                {
                    case GestureStatus.Running:
                        currentFrame.TranslationX = currentFrame.X + e.TotalX;
                        currentFrame.TranslationY = currentFrame.Y + e.TotalY;

                        double strX = ((int)(currentFrame.TranslationX * 100.0)) / 100.0;
                        double strY = ((int)(currentFrame.TranslationY * 100.0)) / 100.0;
                        double strW = ((int)(App.Current.MainPage.Width * 100.0)) / 100.0;
                        double strH = ((int)(App.Current.MainPage.Height * 100.0)) / 100.0;

                        var strFormat = $"X:{strX} Y:{strY} W:{strW} H:{strH}";
                        Title = strFormat;

                        double statusX = App.Current.MainPage.Width - Math.Abs(currentFrame.TranslationX);
                        double percentX = (100 * statusX) / App.Current.MainPage.Width;
                        if (percentX < 50.0 && !IsSwiping)
                        {
                            IsSwiping = true;
                            if (currentFrame.TranslationX < 0)
                            {
                                await Task.WhenAny<bool>(
                                    absLayout.Children[SwipeVM.CurrentFrame].RotateTo(-30, 1000),
                                    absLayout.Children[SwipeVM.CurrentFrame].TranslateTo(-600, -100, 1000)
                                    );
                                SwipeVM.CurrentFrame--;
                            }
                            else
                            {
                                await Task.WhenAny<bool>(
                                    absLayout.Children[SwipeVM.CurrentFrame].RotateTo(30, 1000),
                                    absLayout.Children[SwipeVM.CurrentFrame].TranslateTo(600, -100, 1000)
                                    );
                                SwipeVM.CurrentFrame--;
                            }

                            IsSwiping = false;
                        }
                        break;
                    case GestureStatus.Completed:
                        currentFrame.TranslationX = absLayout.TranslationX;
                        currentFrame.TranslationY = absLayout.TranslationY;
                        break;
                }
            }

        }
    }
}