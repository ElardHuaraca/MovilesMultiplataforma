using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DependecyService
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanerDemo : ContentPage
    {
        public ScanerDemo()
        {
            InitializeComponent();
            BindingContext = new ScannerViewModel(this.Navigation);
        }
    }
}