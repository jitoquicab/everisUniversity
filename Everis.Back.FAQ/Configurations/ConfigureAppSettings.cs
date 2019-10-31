using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Everis.back.FAQ.core.models.configuracion;

namespace Everis.Back.FAQ.Configurations
{
    public static class ConfigureAppSettings
    {
        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SecretsKeyApp>((settings) =>
            {
                configuration.GetSection("SecretsKeyApp").Bind(settings);
            });
#if (DEBUG)
            services.Configure<EndPointsServices>((settings) =>
            {
                configuration.GetSection("MicroServicesPoint_DEV").Bind(settings);
            });

#else
                services.Configure<EndPointsServices>((settings) => {
                    configuration.GetSection("MicroServicesPoint_Release").Bind(settings);
                });
#endif
            return services;
        }
    }
}
