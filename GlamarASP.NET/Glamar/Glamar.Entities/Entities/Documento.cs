using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Documento
    {
        public int idVenta { get; set; }

        public Venta Venta { get; set; }

        public int idDocumento { get; set; }

        public string tipo { get; set; }

        public int idCliente { get; set; }

        public Cliente Cliente { get; set; }
    }
}
