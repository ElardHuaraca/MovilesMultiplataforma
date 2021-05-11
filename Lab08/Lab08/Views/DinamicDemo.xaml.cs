using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab08.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DinamicDemo : ContentPage
    {
        public DinamicDemo()
        {
            InitializeComponent();

            Resources["searchStyle"] = Resources["blueSearchBarStyle"];
            bool estado = false;

            btnBuscar.Clicked += (sender, e) =>
            {
                if (!estado)
                {
                    Resources["searchStyle"] = Resources["greenSearchBarStyle"];
                    estado = true;
                }
                else 
                {
                    Resources["searchStyle"] = Resources["blueSearchBarStyle"];
                    estado = false;
                }
            };
        }
    }
}