using Lab15.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab15.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductoPage : ContentPage
    {
        bool isNewProduct;
        public ProductoPage(bool isNew = false)
        {
            InitializeComponent();
            isNewProduct = isNew;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var producto = (Producto)BindingContext;
            await App.ProductoManager.SaveTaskAsync(producto, !isNewProduct);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var producto = (Producto)BindingContext;
            await App.ProductoManager.DeleteTaskAsync(producto);
            await Navigation.PopAsync();
        }

        async void OnCancelButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}