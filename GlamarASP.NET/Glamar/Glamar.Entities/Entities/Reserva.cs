using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Reserva
    {
        public int idReserva { get; set; }

        public int idVenta { get; set; }

        public Venta Venta { get; set; }

       public string Estado { get; set; }

        public ICollection<Cliente> Clientes { get; set; }

        public List<Itinerario> Itinerarios { get; set; }

        public Reserva()
        {
            Clientes = new HashSet<Cliente>();
            Itinerarios = new List<Itinerario>();
        }

        public Itinerario Itinerario { get; set; }
        public Alojamiento Hospedaje { get; set; }
    }
}
