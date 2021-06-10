using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lab14.Model
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public DateTime Fech_Restblecido { get; set; }
        public int Stock { get; set; }
        public bool Dispo_Delivery { get; set; }

    }
}
