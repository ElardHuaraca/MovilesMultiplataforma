using Lab13.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab13.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Attributes

        #region Commands
        public ICommand SelectMenuItemCommand
        {
            get 
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Commands

        #region Method
        private void SelectMenuItemExecute()
        {
            if (this.Id == 1)
            {
                Application.Current.MainPage.Navigation.PushAsync(new AlbumPage());
            }
            else
            {
                Application.Current.MainPage.Navigation.PushAsync(new AlbumesPage());
            }
        }
        #endregion Method
    }
}
