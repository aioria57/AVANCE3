using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance.EntitiesConfigurations
{
    public class MonedaConfiguration : EntityTypeConfiguration<Moneda>
    {
        public MonedaConfiguration()
        {
            //Table Configurations
            ToTable("Monedas");

            HasKey(m => m.idMoneda);

        }
    }
}
