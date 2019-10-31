using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Everis.back.FAQ.core.rabbit.Context;

namespace Everis.Back.FAQ.Configurations
{
    public static class ConfigureConnections
    {
        /// <summary>
        /// Adds the connection provider.
        /// </summary>
        /// <returns>The connection provider.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static IServiceCollection AddConnectionProvider(this IServiceCollection services, IConfiguration configuration)
        {
            // TODO 3: Se debe configurar las cadenas de conexión a las que son suministradas en el taller.
            //services.AddDbContextPool<FAQContext>(options => options.UseSqlServer(configuration["SecretsKeyApp:DB-ECP-FAQ_"],
            //    sqlServerOptionsAction: sqlOptions =>
            //    {
            //        sqlOptions.EnableRetryOnFailure(
            //        maxRetryCount: 7,
            //        maxRetryDelay: TimeSpan.FromSeconds(10),
            //        errorNumbersToAdd: null);
            //    }));

            return services;
        }
    }
}
