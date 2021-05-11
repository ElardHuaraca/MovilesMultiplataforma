using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DependecyService
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnSpeaker.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TextToSpeechDemo());
            };

            btnBattery.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new BatteryDemo());
            };

            btnScaner.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ScanerDemo());
            };
        }
    }
}
