using Glamar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Glamar.Persistance.EntitiesConfigurations
{
    public class DocumentoConfiguration : EntityTypeConfiguration<Documento>
    {
        public DocumentoConfiguration()
        {
            //Table Configurations
            ToTable("Documentos");

            HasKey(d => d.idDocumento);

            Property(d => d.tipo).HasMaxLength(255);

            //Relations Configurations
            HasRequired(c => c.Cliente)
                .WithRequiredPrincipal(c => c.Documento);

            HasRequired(c => c.Venta)
                .WithRequiredPrincipal(c => c.Documento);

        }
    }
}
