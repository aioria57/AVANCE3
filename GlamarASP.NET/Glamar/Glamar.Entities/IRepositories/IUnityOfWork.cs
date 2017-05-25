using Glamar.Entities.IRepositories;
using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;

namespace Glamar.Entities.IRepositories

{

public interface IUnityOfWork : IDisposable

{

    IAlojamientoRepository Alojamiento { get; }

    IClienteRepository Clientes { get; }

    ICorreoRepository Correos { get; }

    IDocumentoRepository Documentos { get; }

    IEmpleadoRepository Empleados { get; }

    IItinerarioRepository Itinerarios { get; }

    IMonedaRepository Monedas { get; }

    IReservaRepository Reservas { get; }

    ITelefonoRepository Telefonos { get; }

    IVentaRepository Ventas { get; }

    int SaveChanges();

        void StateModified(Object entity);

}

}
