using Lab13.Models;
using Lab13.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Lab13.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }

        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();
            this.SaveArtistas();
        }
        #endregion Contructor

        #region Methods
        private void LoadMenu() 
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();
            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Registros" });
        }
        #endregion Methods

        DBDataAccess<Artista> dataService = new DBDataAccess<Artista>();
        public void SaveArtistas()
        {
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Arjona" },
                new Artista { Nombre = "Luismi" },
                new Artista { Nombre = "Kalimba" }

            };
            for (int i = 0; i < artistas.Count; i++) 
            {
                dataService.AddIfNotExist(artistas[i], x => x.Nombre == artistas[i].Nombre);
            }
        }
    }
}
