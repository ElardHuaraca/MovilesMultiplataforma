using Lab15.Data;
using Lab15.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab15
{
    public partial class App : Application
    {
        public static ProductoManager ProductoManager { get; private set; }
        public App()
        {
            InitializeComponent();
            ProductoManager = new ProductoManager(new RestService());
            MainPage = new NavigationPage(new ProductoListPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
