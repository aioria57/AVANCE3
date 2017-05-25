using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class ReservaConfiguration : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfiguration()
        {
            //Table Configurations
            ToTable("Reservas");

            HasKey(r => r.idReserva);


            //Relations Configurations
            HasRequired(r => r.Venta)
                .WithRequiredPrincipal(r => r.Reserva);

            HasMany(r => r.Clientes)
                .WithMany(r => r.Reservas)
                .Map(m =>
                {
                    m.ToTable("ClienteReservas");
                    m.MapLeftKey("idCliente");
                    m.MapRightKey("idReserva");
                });

        }
    }
}
