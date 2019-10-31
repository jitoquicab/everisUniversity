using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Everis.Back.FAQ.Configurations
{
    public static class ServicesConfiguration
    {
        /// <summary>
        /// Configures the repositories.
        /// </summary>
        /// <returns>The repositories.</returns>
        /// <param name="services">Services.</param>
        /// <param name="configuration">Configuration.</param>
        public static IServiceCollection ConfigureRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }

        /// <summary>
        /// Adds the middleware.
        /// </summary>
        /// <returns>The middleware.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddMiddleware(this IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            return services;
        }

        /// <summary>
        /// Adds the cors configuration.
        /// </summary>
        /// <returns>The cors configuration.</returns>
        /// <param name="services">Services.</param>
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", new Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials()
                    .Build());
            });
    }
}
