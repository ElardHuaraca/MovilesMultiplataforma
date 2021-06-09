using Lab14.Model;
using Lab14.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab14.ViewModel
{
    public class ProductViewModel : BaseViewModel
    {
        #region Service
        private readonly DBDataAccess<Producto> dataServiceProducto;
        #endregion Service

        #region Attribute
        private ObservableCollection<Producto> productos;
        private string idProd;
        private string nombre;
        private DateTime fechaRestablecimiento;
        private int stock;
        private bool dispo_delivery;
        #endregion Attribute

        #region Properties
        public ObservableCollection<Producto> Productos
        {
            get { return this.productos; }
            set { SetValue(ref this.productos, value); }
        }
        public string IdProd
        {
            get { return this.idProd; }
            set { SetValue(ref this.idProd, value); }
        }
        public string Nombre 
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }
        public DateTime Fecha
        {
            get { return this.fechaRestablecimiento; }
            set { SetValue(ref this.fechaRestablecimiento, value); }
        }
        public int Stock
        {
            get { return this.stock; }
            set { SetValue(ref this.stock, value); }
        }
        public string Delivery
        {
            get { return this.dispo_delivery; }
            set 
            {
                System.Diagnostics.Debug.WriteLine("###################################### " + value);
                if (value.Equals("Disponible"))
                {
                    SetValue(ref this.dispo_delivery, true);
                }
                else 
                {
                    SetValue(ref this.dispo_delivery, false);
                }
            }
        }
        #endregion Properties

        #region Command
        public ICommand CreateProduct
        { 
            get 
            {
                return new Command(async () =>
                {
                    var Producto = new Producto()
                    {
                        CodigoProd = this.IdProd,
                        Fech_Restblecido = this.Fecha,
                        Nombre = this.Nombre,
                        Stock = this.Stock,
                        Dispo_Delivery = this.Delivery
                    };
                    if (Producto != null)
                    {
                        if (this.dataServiceProducto.Create(Producto))
                        {
                            await Application.Current.MainPage.DisplayAlert("Producto creado correctamente",
                                $"Producto : { this.Nombre }" + $" creado correctamente en la BD", "OK");
                            this.IdProd = string.Empty;
                            this.Nombre = string.Empty;
                            this.Fecha = DateTime.Now;
                            this.Stock = 0;
                            this.Delivery = false;
                        }
                        else
                        {
                            await Application.Current.MainPage.DisplayAlert("Ocurrio un Error",
                                $"Error al crear el producto", "Ok");

                        }
                    }
                });
            }
        }

        public ICommand test
        {
            get
            {
                return new Command( () =>
                {
                    Console.WriteLine(this.Fecha);
                    Console.WriteLine(this.Delivery);
                });
            }
        }
        #endregion Command

        #region Method
        private void LoadProductos() 
        {
            var productosDB = this.dataServiceProducto.Get().ToList();
            this.Productos = new ObservableCollection<Producto>(productosDB);
        }
        #endregion Method

        #region Constructor
        public ProductViewModel()
        {
            this.dataServiceProducto = new DBDataAccess<Producto>();
            this.Fecha = DateTime.Now;
            this.LoadProductos();
        }
        #endregion Constructor
    }
}
