/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

using Microsoft.Extensions.DependencyInjection;
using SchoolBusAPI.Services;
using SchoolBusAPI.Services.Impl;

namespace SchoolBusAPI
{
    /// <summary>
    /// Utility extension added to aspnet core to facilitate registration of application-specific services
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds application-specific services to the dependency injection container in aspnet core.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ISchoolBusApiService, SchoolBusApiService>();
            // ...and a lot more services!

            return services;
        }
    }
}
