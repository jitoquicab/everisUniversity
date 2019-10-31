using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everis.Back.FAQ.Configurations
{
    public static class SwaggerConfiguration
    {
        /// <summary>
        /// Adds the swagger configuration.
        /// </summary>
        /// <returns>The swagger configuration.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {

            // TODO 1 : Se debe tomar el código que esta en el taller y bicarlo en la lena 22, este sirve para poder configurar swagger como herramieta de documentación
            //services.AddSwaggerGen(options =>
            //{
            //    options.DescribeAllEnumsAsStrings();
            //    options.SwaggerDoc("v1", new Info
            //    {
            //        Title = "everis - FAQ HTTP API",
            //        Version = "v1",
            //        Description = "API HTTP de FAQ. Este microservicio sirve para verificar la autenticidad de un usuario y sus roles de acceso. ",
            //        TermsOfService = "Terminos del servicio"
            //    });
            //});

            return services;
        }
    }
}
