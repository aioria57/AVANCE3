using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Venta
    {
        public int idVenta { get; set; }

        public int idEmpleado { get; set; }

        public Empleado Empleado { get; set; }

        public int MonedaId { get; set; }

        public Moneda Moneda { get; set; }

        public double monto { get; set; }
        public Documento Documento { get; set; }
        public Reserva Reserva { get; set; }
    }
}
