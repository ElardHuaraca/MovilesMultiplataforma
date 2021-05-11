using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Alumno
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreCompleto { get { return this.Nombre + " " + this.Apellido; } }
    }
}
