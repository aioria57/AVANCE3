using System;
using System.Collections.Generic;
using System.Text;

namespace Glamar.Entities
{
    public class Moneda
    {
        public int idMoneda { get; set; }

        public string descripcion { get; set; }

        public List<Venta> Ventas { get; set; }

        public Moneda()
        {
            Ventas = new List<Venta>();
        }
        public Venta Venta { get; set; }
    }
}
