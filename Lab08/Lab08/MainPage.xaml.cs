using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Lab08.Views;

namespace Lab08
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnExplicit.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ExplicitDemo());
            };

            btnExplicitControl.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ExplicitControlDemo());
            };

            btnImplicit.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ImplicitDemo());
            };

            btnImplicitControl.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ImplicitControlDemo());
            };

            btnGlobal.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new GlobalDemo());
            };

            btnInheritance.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new InheritanceDemo());
            };

            btnDynamic.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new DinamicDemo());
            };

            btnClass.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new ClassDemo());
            };

            btnCss.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new cssDemo());
            };

        }
    }
}
