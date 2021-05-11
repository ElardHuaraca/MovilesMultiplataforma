using System;
using System.Collections.Generic;
using System.Text;

namespace Lab6
{
    public class Seccion : List<Alumno>
    {
        public string Secciones { get; set; }
        public List<Alumno> Alumnos => this;
    }
}
