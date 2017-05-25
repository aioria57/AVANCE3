using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class ItinerarioConfiguration : EntityTypeConfiguration<Itinerario>
    {
        public ItinerarioConfiguration()
        {
            //Table Configurations
            ToTable("Itinerarios");

            HasKey(i => i.idItinerario);

            //Relations Configurations
            HasRequired(i => i.Reserva)
                .WithMany(c => c.Itinerarios);

        }
    }
}