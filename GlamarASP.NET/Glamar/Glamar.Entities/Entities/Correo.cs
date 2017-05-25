using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Correo
    {
        public int idCorreo { get; set; }

        public int idCliente { get; set; }

        public Cliente Cliente { get; set; }

        public string tipo { get; set; }
    }
}
