using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Itinerario
    {
        public int idItinerario { get; set; }

        public int idReserva { get; set; }

        public Reserva Reserva { get; set; }

        public string origen { get; set; }

        public string destino { get; set; }

        public DateTime fecSalida { get; set; }

        public DateTime fecRetorno { get; set; }

        public int distancia { get; set; }
    }
}
