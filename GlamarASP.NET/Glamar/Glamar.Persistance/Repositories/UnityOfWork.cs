using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Glamar.Entities.IRepositories;
using Glamar.Persistance;
using Glamar.Persistence.Repositoriess;

namespace Glamar.Persistence.Repositories

{

    public class UnityOfWork : IUnityOfWork

    {
        private readonly GlamarDbContext _Context;

        private static UnityOfWork _Instance;

        private static readonly object _Lock = new object();

        public IAlojamientoRepository Alojamiento { get; private set; }

        public IClienteRepository Clientes { get; private set; }

        public ICorreoRepository Correos { get; private set; }

        public IDocumentoRepository Documentos { get; private set; }

        public IEmpleadoRepository Empleados { get; private set; }

        public IItinerarioRepository Itinerarios { get; private set; }

        public IMonedaRepository Monedas { get; private set; }

        public IReservaRepository Reservas { get; private set; }

        public ITelefonoRepository Telefonos { get; private set; }

        public IVentaRepository Ventas { get; private set; }

        private UnityOfWork()

        {

            _Context = new GlamarDbContext();

            Alojamiento = new AlojamientoRepository(_Context);

            Clientes = new ClienteRepository(_Context);

            Correos = new CorreoRepository(_Context);

            Documentos = new DocumentoRepository(_Context);

            Empleados = new EmpleadoRepository(_Context);

            Itinerarios = new ItinerarioRepository(_Context);

            Monedas = new MonedaRepository(_Context);

            Reservas = new ReservaRepository(_Context);

            Telefonos = new TelefonoRepository(_Context);

            Ventas = new VentaRepository(_Context);

        }

        public static UnityOfWork Instance

        {

            get

            {

                lock (_Lock)

                {

                    if (_Instance == null)

                        _Instance = new UnityOfWork();

                }

                return _Instance;

            }

        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }

}