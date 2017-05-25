using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Telefono
    {
        public int idTelefono { get; set; }

        public int idCliente { get; set; }

        public Cliente Cliente { get; set; }

        public int  numero { get; set; }

        public string tipo { get; set; }
    }
}
