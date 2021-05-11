using Lab10.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lab10
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            viewtoviewdemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ViewToViewDemo());
            };

            bindingdemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new BindingModeDemo());
            };

            listdemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ListViewDemo());
            };

            pickerdemo.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new PickerDemo());
            };
        }
    }
}
