using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Entities
{
    public class Cliente
    {
        public int idCliente { get; set; }

        public string nombres { get; set; }

        public string primApe { get; set; }

        public string segApe { get; set; }

        public int puntosDisponibles { get; set; }

        public Documento Documento { get; set; }

        public List<Reserva> Reservas { get; set; }

        public List<Telefono> Telefonos { get; set; }

        public List<Correo> Correos { get; set; }

        public Cliente()
        {
            Reservas = new List<Reserva>();

            Correos = new List<Correo>();

            Telefonos = new List<Telefono>();
        }
        public Reserva Reserva { get; set; }

        public Telefono Telefono { get; set; }

        public Correo Correo { get; set; }

    }
}
