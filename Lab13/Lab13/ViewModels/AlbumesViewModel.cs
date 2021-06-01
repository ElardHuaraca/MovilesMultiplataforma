using Lab13.Models;
using Lab13.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab13.ViewModels
{
    public class AlbumesViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<Artista> dataServiceArtistas;
        private readonly DBDataAccess<Album> dataServiceAlbumes;
        #endregion Services

        #region Attribute
        private ObservableCollection<Artista> artistas;
        private ObservableCollection<Album> albumes;
        private Artista selectedArtista;
        private string titulo;
        private double precio;
        private int año;
        #endregion Attribute

        #region Properties
        public ObservableCollection<Artista> Artistas
        {
            get { return this.artistas; }
            set { SetValue(ref this.artistas, value); }
        }
        public ObservableCollection<Album> Albumes
        {
            get { return this.albumes; }
            set { SetValue(ref this.albumes, value); }
        }
        public Artista SelectedArtista
        {
            get { return this.selectedArtista; }
            set { SetValue(ref this.selectedArtista, value); }
        }
        public string Titulo
        {
            get { return this.titulo; }
            set { SetValue(ref this.titulo, value); }
        }
        public double Precio
        {
            get { return this.precio; }
            set { SetValue(ref this.precio, value); }
        }
        public int Año
        {
            get { return this.año; }
            set { SetValue(ref this.año, value); }
        }
        #endregion Properties

        #region Constructor
        public AlbumesViewModel()
        {
            this.dataServiceArtistas = new DBDataAccess<Artista>();
            this.dataServiceAlbumes = new DBDataAccess<Album>();
            
            //this.CreateArtistas();
            this.LoadArtistas();
            this.LoadAlbumes();
            this.Año = DateTime.Now.Year;
        }
        #endregion Constructor

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newAlbum = new Album()
                    {
                        ArtistaID = this.SelectedArtista.ArtistaID,
                        Titulo = this.Titulo,
                        Precio = this.Precio,
                        Año = this.Año
                    };
                    if (newAlbum != null)
                    {
                        if (this.dataServiceAlbumes.Create(newAlbum))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operacion exitosa",
                                $"Album del artista: { this.selectedArtista.Nombre}" + $"creado correctamente en la base de datos", "OK");
                            this.SelectedArtista = null;
                            this.Titulo = string.Empty;
                            this.Precio = 0;
                            this.Año = DateTime.Now.Year;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Operacion fallida",
                                $"Error al crear el Album en la base de datos", "OK");
                        }
                    }
                });
            }
        }
        #endregion Commands

        #region Methods
        private void LoadArtistas() 
        {
            var artistasDB = this.dataServiceArtistas.Get().ToList() as List<Artista>;
            this.Artistas = new ObservableCollection<Artista>(artistasDB);
        }
        private void LoadAlbumes()
        {
            var albumesDB = this.dataServiceAlbumes.Get(null, null, "Artista").ToList() as List<Album>;
            this.Albumes = new ObservableCollection<Album>(albumesDB);
        }
        private void CreateArtistas()
        {
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Ricardo Arjona" },
                new Artista { Nombre = "Kalimba" },
                new Artista { Nombre = "Luis Miguel" }
            };

            this.dataServiceArtistas.SaveList(artistas);
        }

        #endregion Methods
    }
}
