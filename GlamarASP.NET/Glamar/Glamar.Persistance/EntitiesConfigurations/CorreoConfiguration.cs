using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class CorreoConfiguration : EntityTypeConfiguration<Correo>
    {
        public CorreoConfiguration()
        {
            //Table Configurations
            ToTable("Correos");

            HasKey(c => new {c.idCorreo, c.Cliente });

            //Relations Configurations
            HasRequired(c => c.Cliente)
                 .WithMany(c => c.Correos);
        }
    }
}
