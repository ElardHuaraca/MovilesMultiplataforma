using Lab16.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab16.ViewModel
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
                Application.Current.MainPage.Navigation.PushAsync(new CreateStudentPage());
            }
            else if (Id == 2)
            {
                Application.Current.MainPage.Navigation.PushAsync(new ShowStudentPage());
            }
            else
            {
                Application.Current.MainPage.Navigation.PushAsync(new FindStudentage());
            }

        }
        #endregion Method
    }
}
