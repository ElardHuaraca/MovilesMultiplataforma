using Lab09.ViewController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab09
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            tapDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TapDemo());
            };

            pinchDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new PinchDemo());
            };

            panDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new PanDemo());
            };

            swipDemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new SwipeDemo());
            };
        }
    }
}
