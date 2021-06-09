using Lab14.DataContext;
using Lab14.Interface;
using Lab14.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab14
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //GetContext().Database.EnsureDeleted();
            GetContext().Database.EnsureCreated();
            //MainPage = new MainPage();
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new CreateProductPage();
        }

        public static AppDBContext GetContext() 
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("Lab14.db");
            return new AppDBContext(DbPath);
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
