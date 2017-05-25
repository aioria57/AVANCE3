using Glamar.Entities;
using Glamar.Persistance.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glamar.Persistance
{
    public class GlamarDbContext : DbContext
    {
        public DbSet<Alojamiento> Alojamientos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Correo> Correos { get; set; }

        public DbSet<Documento> Documentos { get; set; }

        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Itinerario> Itinerarios { get; set; }

        public DbSet<Moneda> Monedas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Venta> Ventas { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlojamientoConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new CorreoConfiguration());
            modelBuilder.Configurations.Add(new DocumentoConfiguration());
            modelBuilder.Configurations.Add(new EmpleadoConfiguration());
            modelBuilder.Configurations.Add(new ItinerarioConfiguration());
            modelBuilder.Configurations.Add(new MonedaConfiguration());
            modelBuilder.Configurations.Add(new ReservaConfiguration());
            modelBuilder.Configurations.Add(new TelefonoConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
