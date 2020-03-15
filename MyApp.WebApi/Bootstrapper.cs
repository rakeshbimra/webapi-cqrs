using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Context.SimpleInjector;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.WebApi
{
    public static class Bootstrapper
    {
        public static void Bootstrap(this IServiceCollection services, Container container)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IControllerActivator>(
                new SimpleInjectorControllerActivator(container));

            services.UseSimpleInjectorAspNetRequestScoping(container);

            // Sets up the basic configuration that for integrating Simple Injector with
            // ASP.NET Core by setting the DefaultScopedLifestyle, and setting up auto
            // cross wiring.
            services.AddSimpleInjector(container, options =>
            {
                // AddAspNetCore() wraps web requests in a Simple Injector scope and
                // allows request-scoped framework services to be resolved.
                options.AddAspNetCore()

                    // Ensure activation of a specific framework type to be created by
                    // Simple Injector instead of the built-in configuration system.
                    // All calls are optional. You can enable what you need. For instance,
                    // PageModels and TagHelpers are not needed when you build a Web API.
                    .AddControllerActivation();
            });


        }
        public static void InitializeContainer(this IApplicationBuilder app,
           Container container, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {

            WebBootstrapper.Bootstrap(container);
        }

        public class WebBootstrapper
        {
            public static void Bootstrap(Container container)
            {
                MyAppBootstrapper.Bootstrap(container, null, false);
                 //container.Verify();
            }
        }

    }
    
}
