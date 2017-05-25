using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Alojamiento
    {
        public int idAlojamiento { get; set; }

        public int idReserva { get; set; }

        public Reserva Reserva { get; set; }

        public string nomHospedaje { get; set; }

        public int  nroHab { get; set; }
    }
}
