using Lab14.Model;
using Lab14.Service;
using Lab14.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab14.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditProductPage : ContentPage
    {
        public EditProductPage(Producto producto,DBDataAccess<Producto> dBDataAccess)
        {
            InitializeComponent();

            this.BindingContext = new EditViewModel(producto, dBDataAccess);
        }
    }
}