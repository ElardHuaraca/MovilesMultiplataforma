using Lab14.Model;
using Lab14.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lab14.ViewModel
{
    public class EditViewModel : BaseViewModel
    {
        #region Attribute
        private Producto producto;
        private readonly DBDataAccess<Producto> dataServiceProducto;
        #endregion Attribute

        #region Properties
        public Producto Producto
        {
            get { return this.producto; }
            set { SetValue(ref this.producto, value); }
        }
        #endregion Properties

        #region Command
        public ICommand UpadteProduct
        {
            get
            {
                return new Command(async () =>
                {
                    if (this.dataServiceProducto.Update(this.Producto))
                    {
                        await Application.Current.MainPage.DisplayAlert("Producto actualizado correctamente",
                            "El producto fue actualizado", "OK");
                        this.Producto = null;
                        MessagingCenter.Send<string>("OK", "completado");
                        await Application.Current.MainPage.Navigation.PopAsync();
                    }
                    else
                    {
                        await Application.Current.MainPage.DisplayAlert("Ocurrio un Error",
                            "Error al intentar actualizar el producto", "Ok");

                    }
                });
            }
        }
        #endregion Command

        #region Constructor
        public EditViewModel(Producto producto,DBDataAccess<Producto> dBDataAccess)
        {
            this.Producto = producto;
            this.dataServiceProducto = dBDataAccess;
        }
        #endregion Constructor
    }
}
