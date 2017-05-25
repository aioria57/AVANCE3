using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class VentaConfiguration : EntityTypeConfiguration<Venta>
    {
        public VentaConfiguration()
        {
            //Table Configurations
            ToTable("Ventas");

            HasKey(v => v.idVenta);

            //Relations Configurations
            HasRequired(v => v.Empleado)
                 .WithMany(v => v.Ventas);

            HasRequired(v => v.Moneda)
                 .WithMany(v => v.Ventas);
        }
    }
}
