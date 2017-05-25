using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class TelefonoConfiguration : EntityTypeConfiguration<Telefono>
    {
        public TelefonoConfiguration()
        {
            //Table Configurations
            ToTable("Telefonos");

            HasKey(t => new { t.idTelefono, t.idCliente });

            //Relations Configurations
            HasRequired(t => t.Cliente)
                 .WithMany(t => t.Telefonos);
        }
    }
}
