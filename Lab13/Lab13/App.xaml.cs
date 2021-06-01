using Lab13.DataContext;
using Lab13.Interfaces;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab13
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //GetContext().Database.EnsureDeleted();
            GetContext().Database.EnsureCreated();
            MainPage = new NavigationPage(new MainPage());
        }

        public static AppDBContext GetContext()
        {
            string DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("Lab13Core.db");
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
