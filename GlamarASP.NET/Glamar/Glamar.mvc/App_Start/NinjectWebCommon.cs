[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Glamar.mvc.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Glamar.mvc.App_Start.NinjectWebCommon), "Stop")]

namespace Glamar.mvc.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Glamar.Persistence.Repositories;
    using Glamar.Entities.IRepositories;
    using Glamar.Persistence;
    using Glamar.Persistance;
    using Glamar.Persistence.Repositoriess;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            //IUnityOfWork -> UnityOfWOrk
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();
            kernel.Bind<GlamarDbContext>().To<GlamarDbContext>();

            kernel.Bind<IAlojamientoRepository>().To<AlojamientoRepository>();
            kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            kernel.Bind<ICorreoRepository>().To<CorreoRepository>();
            kernel.Bind<IDocumentoRepository>().To<DocumentoRepository>();
            kernel.Bind<IEmpleadoRepository>().To<EmpleadoRepository>();
            kernel.Bind<IItinerarioRepository>().To<ItinerarioRepository>();
            kernel.Bind<IMonedaRepository>().To<MonedaRepository>();
            kernel.Bind<IReservaRepository>().To<ReservaRepository>();
            kernel.Bind<ITelefonoRepository>().To<TelefonoRepository>();
            kernel.Bind<IVentaRepository>().To<VentaRepository>();

        }        
    }
}
