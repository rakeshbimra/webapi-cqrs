using log4net;
using Microsoft.EntityFrameworkCore;
using MyApp.Context.CQRS.Commands;
using MyApp.Context.CQRS.Queries;
using MyApp.Context.Domain;
using MyApp.Context.Domain.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MyApp.Context.SimpleInjector
{
    public class MyAppBootstrapper
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(MyAppBootstrapper));
        public static void Bootstrap(Container container, IEnumerable<Assembly> assemblies = null, bool verifyContainer = true)
        {
            _logger.Info("Going to register objects in container");

            container.Register(typeof(IRepository<>), typeof(Repository<>).Assembly);

            container.Register<IUnitOfWork, UnitOfWork<ProductCatalogContext>>(Lifestyle.Scoped);

            //container.Register<ProductCatalogContext>(() =>
            //{
            //    var options = new DbContextOptions<ProductCatalogContext>();
            //    return new ProductCatalogContext(options);
            //});

            container.Register<ProductCatalogContext>(Lifestyle.Scoped);

           

            List<Assembly> myContextAssemlies = new List<Assembly>
                {
                     Assembly.GetAssembly(typeof(AddProductCommandHandler)),
                     Assembly.GetAssembly(typeof(RetrieveProductQueryHandler)),
                };

            container.Register(typeof(IQueryHandler<,>), myContextAssemlies, Lifestyle.Scoped);

            container.Register(typeof(ICommandHandler<>), myContextAssemlies, Lifestyle.Scoped);

            if (assemblies == null)
            {
                assemblies = myContextAssemlies;
            }
            else
            {
                assemblies.Union(myContextAssemlies);
            }

            if (container == null)
            {
                throw new ArgumentNullException("container", "Container could not be null");
            }

            if (verifyContainer)
            {
                container.Verify();

                _logger.Info("Container verified:" + container);
            }
        }
    }
}
