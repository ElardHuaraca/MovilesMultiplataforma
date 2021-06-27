using Lab16.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab16
{
    public partial class App : Application
    {
        public static StudentManager StudentManager { get; private set; }
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            StudentManager = new StudentManager(new RestService());
            MainPage = new NavigationPage(new MainPage());
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
