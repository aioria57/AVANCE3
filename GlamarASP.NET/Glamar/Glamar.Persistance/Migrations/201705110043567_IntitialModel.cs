namespace Glamar.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alojamientos",
                c => new
                    {
                        idAlojamiento = c.Int(nullable: false),
                        idReserva = c.Int(nullable: false),
                        nomHospedaje = c.String(),
                        nroHab = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idAlojamiento)
                .ForeignKey("dbo.Reservas", t => t.idAlojamiento)
                .Index(t => t.idAlojamiento);
            
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        idReserva = c.Int(nullable: false, identity: true),
                        idVenta = c.Int(nullable: false),
                        Estado = c.String(),
                        Itinerario_idItinerario = c.Int(),
                    })
                .PrimaryKey(t => t.idReserva)
                .ForeignKey("dbo.Itinerarios", t => t.Itinerario_idItinerario)
                .Index(t => t.Itinerario_idItinerario);
            
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        idCliente = c.Int(nullable: false),
                        nombres = c.String(maxLength: 255),
                        primApe = c.String(),
                        segApe = c.String(),
                        puntosDisponibles = c.Int(nullable: false),
                        Correo_idCorreo = c.Int(),
                        Correo_idCliente = c.Int(),
                        Reserva_idReserva = c.Int(),
                        Telefono_idTelefono = c.Int(),
                        Telefono_idCliente = c.Int(),
                    })
                .PrimaryKey(t => t.idCliente)
                .ForeignKey("dbo.Correos", t => new { t.Correo_idCorreo, t.Correo_idCliente })
                .ForeignKey("dbo.Documentos", t => t.idCliente)
                .ForeignKey("dbo.Reservas", t => t.Reserva_idReserva)
                .ForeignKey("dbo.Telefonos", t => new { t.Telefono_idTelefono, t.Telefono_idCliente })
                .Index(t => t.idCliente)
                .Index(t => new { t.Correo_idCorreo, t.Correo_idCliente })
                .Index(t => t.Reserva_idReserva)
                .Index(t => new { t.Telefono_idTelefono, t.Telefono_idCliente });
            
            CreateTable(
                "dbo.Correos",
                c => new
                    {
                        idCorreo = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        tipo = c.String(),
                        Cliente_idCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idCorreo, t.idCliente })
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente, cascadeDelete: true)
                .Index(t => t.Cliente_idCliente);
            
            CreateTable(
                "dbo.Documentos",
                c => new
                    {
                        idDocumento = c.Int(nullable: false, identity: true),
                        idVenta = c.Int(nullable: false),
                        tipo = c.String(maxLength: 255),
                        idCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idDocumento);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        idVenta = c.Int(nullable: false),
                        idEmpleado = c.Int(nullable: false),
                        idMoneda = c.Int(nullable: false),
                        monto = c.Double(nullable: false),
                        Empleado_idEmpleado = c.Int(nullable: false),
                        Moneda_idMoneda = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idVenta)
                .ForeignKey("dbo.Empleados", t => t.Empleado_idEmpleado, cascadeDelete: true)
                .ForeignKey("dbo.Monedas", t => t.Moneda_idMoneda, cascadeDelete: true)
                .ForeignKey("dbo.Documentos", t => t.idVenta)
                .ForeignKey("dbo.Reservas", t => t.idVenta)
                .Index(t => t.idVenta)
                .Index(t => t.Empleado_idEmpleado)
                .Index(t => t.Moneda_idMoneda);
            
            CreateTable(
                "dbo.Empleados",
                c => new
                    {
                        idEmpleado = c.Int(nullable: false, identity: true),
                        apellidos = c.String(),
                        nombres = c.String(),
                        Venta_idVenta = c.Int(),
                    })
                .PrimaryKey(t => t.idEmpleado)
                .ForeignKey("dbo.Ventas", t => t.Venta_idVenta)
                .Index(t => t.Venta_idVenta);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        idMoneda = c.Int(nullable: false, identity: true),
                        descripcion = c.String(),
                        Venta_idVenta = c.Int(),
                    })
                .PrimaryKey(t => t.idMoneda)
                .ForeignKey("dbo.Ventas", t => t.Venta_idVenta)
                .Index(t => t.Venta_idVenta);
            
            CreateTable(
                "dbo.Telefonos",
                c => new
                    {
                        idTelefono = c.Int(nullable: false),
                        idCliente = c.Int(nullable: false),
                        numero = c.Int(nullable: false),
                        tipo = c.String(),
                        Cliente_idCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idTelefono, t.idCliente })
                .ForeignKey("dbo.Clientes", t => t.Cliente_idCliente, cascadeDelete: true)
                .Index(t => t.Cliente_idCliente);
            
            CreateTable(
                "dbo.Itinerarios",
                c => new
                    {
                        idItinerario = c.Int(nullable: false, identity: true),
                        idReserva = c.Int(nullable: false),
                        origen = c.String(),
                        destino = c.String(),
                        fecSalida = c.DateTime(nullable: false),
                        fecRetorno = c.DateTime(nullable: false),
                        distancia = c.Int(nullable: false),
                        Reserva_idReserva = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idItinerario)
                .ForeignKey("dbo.Reservas", t => t.Reserva_idReserva, cascadeDelete: true)
                .Index(t => t.Reserva_idReserva);
            
            CreateTable(
                "dbo.ClienteReservas",
                c => new
                    {
                        idCliente = c.Int(nullable: false),
                        idReserva = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.idCliente, t.idReserva })
                .ForeignKey("dbo.Reservas", t => t.idCliente, cascadeDelete: true)
                .ForeignKey("dbo.Clientes", t => t.idReserva, cascadeDelete: true)
                .Index(t => t.idCliente)
                .Index(t => t.idReserva);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Alojamientos", "idAlojamiento", "dbo.Reservas");
            DropForeignKey("dbo.Ventas", "idVenta", "dbo.Reservas");
            DropForeignKey("dbo.Reservas", "Itinerario_idItinerario", "dbo.Itinerarios");
            DropForeignKey("dbo.Itinerarios", "Reserva_idReserva", "dbo.Reservas");
            DropForeignKey("dbo.ClienteReservas", "idReserva", "dbo.Clientes");
            DropForeignKey("dbo.ClienteReservas", "idCliente", "dbo.Reservas");
            DropForeignKey("dbo.Clientes", new[] { "Telefono_idTelefono", "Telefono_idCliente" }, "dbo.Telefonos");
            DropForeignKey("dbo.Telefonos", "Cliente_idCliente", "dbo.Clientes");
            DropForeignKey("dbo.Clientes", "Reserva_idReserva", "dbo.Reservas");
            DropForeignKey("dbo.Ventas", "idVenta", "dbo.Documentos");
            DropForeignKey("dbo.Ventas", "Moneda_idMoneda", "dbo.Monedas");
            DropForeignKey("dbo.Monedas", "Venta_idVenta", "dbo.Ventas");
            DropForeignKey("dbo.Ventas", "Empleado_idEmpleado", "dbo.Empleados");
            DropForeignKey("dbo.Empleados", "Venta_idVenta", "dbo.Ventas");
            DropForeignKey("dbo.Clientes", "idCliente", "dbo.Documentos");
            DropForeignKey("dbo.Clientes", new[] { "Correo_idCorreo", "Correo_idCliente" }, "dbo.Correos");
            DropForeignKey("dbo.Correos", "Cliente_idCliente", "dbo.Clientes");
            DropIndex("dbo.ClienteReservas", new[] { "idReserva" });
            DropIndex("dbo.ClienteReservas", new[] { "idCliente" });
            DropIndex("dbo.Itinerarios", new[] { "Reserva_idReserva" });
            DropIndex("dbo.Telefonos", new[] { "Cliente_idCliente" });
            DropIndex("dbo.Monedas", new[] { "Venta_idVenta" });
            DropIndex("dbo.Empleados", new[] { "Venta_idVenta" });
            DropIndex("dbo.Ventas", new[] { "Moneda_idMoneda" });
            DropIndex("dbo.Ventas", new[] { "Empleado_idEmpleado" });
            DropIndex("dbo.Ventas", new[] { "idVenta" });
            DropIndex("dbo.Correos", new[] { "Cliente_idCliente" });
            DropIndex("dbo.Clientes", new[] { "Telefono_idTelefono", "Telefono_idCliente" });
            DropIndex("dbo.Clientes", new[] { "Reserva_idReserva" });
            DropIndex("dbo.Clientes", new[] { "Correo_idCorreo", "Correo_idCliente" });
            DropIndex("dbo.Clientes", new[] { "idCliente" });
            DropIndex("dbo.Reservas", new[] { "Itinerario_idItinerario" });
            DropIndex("dbo.Alojamientos", new[] { "idAlojamiento" });
            DropTable("dbo.ClienteReservas");
            DropTable("dbo.Itinerarios");
            DropTable("dbo.Telefonos");
            DropTable("dbo.Monedas");
            DropTable("dbo.Empleados");
            DropTable("dbo.Ventas");
            DropTable("dbo.Documentos");
            DropTable("dbo.Correos");
            DropTable("dbo.Clientes");
            DropTable("dbo.Reservas");
            DropTable("dbo.Alojamientos");
        }
    }
}
