using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Empleado
    {
        public int idEmpleado { get; set; }

        public string apellidos { get; set; }

        public string nombres { get; set; }

        public List<Venta> Ventas { get; set; }

        public Empleado()
        {
            Ventas = new List<Venta>();
        }
        public Venta Venta{ get; set; }

    }
}
