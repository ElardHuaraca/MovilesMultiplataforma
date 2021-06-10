using Lab14.Model;
using Lab14.Service;
using Lab14.View;
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
        private ObservableCollection<Producto> productosfind;
        private Producto producto;
        private int idProd;
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
        public ObservableCollection<Producto> ProductosFind
        {
            get { return this.productosfind; }
            set { SetValue(ref this.productosfind, value); }
        }
        public Producto Producto
        {
            get { return this.producto; }
            set { SetValue(ref this.producto, value); }
        }
        public int IdProd
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
        public bool Delivery
        {
            get { return this.dispo_delivery; }
            set 
            {
                SetValue(ref this.dispo_delivery, value);
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
                        ProductoId = this.IdProd,
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
                            this.IdProd = 1;
                            this.Nombre = string.Empty;
                            this.Fecha = DateTime.Now;
                            this.Stock = 1;
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

        public ICommand EditProduct
        {
            get 
            {
                return new Command(async () => 
                {
                    if (this.Producto != null)
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new EditProductPage(this.Producto,this.dataServiceProducto));
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Adevertencia¡",
                            "Se debe escoger un producto primero", "OK");
                    }
                });
            }
        }

        public void SearchChanged(object sender, TextChangedEventArgs arg)
        {
            
        }
        public ICommand DeleteProduct
        {
            get
            {
                return new Command( async () =>
                {
                    if (this.Producto != null)
                    {

                        bool answer = await Application.Current.MainPage.DisplayAlert("Confirmacion"
                            ,$"¿Desea eliminar el producto: { this.Producto.Nombre }?","Si","No");
                        if (answer)
                        {
                            if (!this.dataServiceProducto.Delete(x => x.ProductoId == this.Producto.ProductoId))
                            {
                                await Application.Current.MainPage.DisplayAlert("Ocurrio un error",
                                "Se produjo un error al intentar eliminar el producto", "OK");
                            }
                            else
                            {
                                await Application.Current.MainPage.DisplayAlert("Producto Eliminado",
                                $"Se elimino correctamente el producto: { this.Producto.Nombre }", "OK");
                                this.Producto = null;
                                LoadProductos();
                            }
                        }
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Adevertencia¡",
                            "Se debe escoger un producto primero", "OK");
                    }
                });
            }
        }

        public ICommand Search
        {
            get 
            {
                return new Command<string>((text) =>
                {
                    Console.WriteLine("sads :" + text);
                    var products = this.dataServiceProducto.Get((x => x.Nombre.Contains(text))).ToList();
                    Console.WriteLine(products);
                    this.ProductosFind = new ObservableCollection<Producto>(products);
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
            MessagingCenter.Subscribe<string>(this, "completado", (arg) =>
              {
                  if (arg.Equals("OK"))
                  {
                      this.LoadProductos();
                      this.ProductosFind = null;
                      this.Producto = null;
                  }
              });
        }
        #endregion Constructor
    }
}
