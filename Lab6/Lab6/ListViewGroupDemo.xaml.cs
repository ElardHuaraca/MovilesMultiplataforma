using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewGroupDemo : ContentPage
    {
        private ObservableCollection<Seccion> seccions = new ObservableCollection<Seccion>();
        public ObservableCollection<Seccion> Seccions { get { return seccions; } }
        public ListViewGroupDemo()
        {
            InitializeComponent();

            var seccionA = new Seccion
            {
                Secciones = "A",
                Alumnos = { 
                    new Alumno { Apellido = "Huaraca", Nombre = "Elard" },
                    new Alumno { Apellido = "Chaca", Nombre = "Obed" }
                }
            };

            var seccionB = new Seccion
            {
                Secciones = "B",
                Alumnos = { 
                    new Alumno { Apellido = "Hugo", Nombre = "Torrico" },
                    new Alumno { Apellido = "Cueva", Nombre = "Brandom" }
                }
            };

            listViewSeccions.ItemsSource = seccions;

            seccions.Add(seccionA);
            seccions.Add(seccionB);
        }
    }
}