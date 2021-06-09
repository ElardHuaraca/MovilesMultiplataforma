using Lab14.Model;
using Lab14.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lab14.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItem> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItem> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu() 
        {
            this.Menu = new ObservableCollection<MenuItem>();
            this.Menu.Clear();
            this.Menu.Add(new MenuItem { Id = 1, TextContent = "Crear Producto" });
            this.Menu.Add(new MenuItem { Id = 2, TextContent = "Listar Productos" });
            this.Menu.Add(new MenuItem { Id = 3, TextContent = "Buscar Producto" });
        }
        #endregion Methods
    }
}
