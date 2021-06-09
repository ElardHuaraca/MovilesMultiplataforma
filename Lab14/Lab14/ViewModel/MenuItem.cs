using Lab14.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab14.ViewModel
{
    public class MenuItem
    {
        public int Id { get; set; }
        public String TextContent { get; set; }

        #region Command
        public ICommand SelectMenuItem 
        {
            get { return new Command(SelectMenuItemExecute); }
        }
        #endregion Command

        #region Method
        private void SelectMenuItemExecute() 
        {
            if (Id == 1)
            {
                Application.Current.MainPage.Navigation.PushAsync(new CreateProductPage());
            }
            else if (Id == 2)
            {
                Application.Current.MainPage.Navigation.PushAsync(new ShowProductPage());
            }
            else 
            {
                Application.Current.MainPage.Navigation.PushAsync(new FindProductPage());
            }
            
        }
        #endregion Method
    }
}
