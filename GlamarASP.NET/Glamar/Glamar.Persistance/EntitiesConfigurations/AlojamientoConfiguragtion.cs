using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class AlojamientoConfiguration : EntityTypeConfiguration<Alojamiento>
    {
        public AlojamientoConfiguration()
        {
            //Table Configurations
            ToTable("Alojamientos");

            HasKey(a => a.idAlojamiento);

            //Relations Configurations
            HasRequired(a => a.Reserva)
                .WithOptional(a => a.Hospedaje);

        }
    }
}