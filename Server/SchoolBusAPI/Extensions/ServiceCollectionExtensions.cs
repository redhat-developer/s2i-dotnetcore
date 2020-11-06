/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SchoolBusAPI.Controllers;
using SchoolBusAPI.Hangfire;
using SchoolBusAPI.Mappings;
using SchoolBusAPI.Services;

namespace SchoolBusAPI.Extensions
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
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<ICCWDataService, CCWDataService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IInspectionService, InspectionService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<IRegionService, RegionService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ISchoolBusService, SchoolBusService>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ISchoolBusOwnerService, SchoolBusOwnerService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IHistoryService, HistoryService>();
            services.AddScoped<ISchoolDistrictService, SchoolDistrictService>();
            services.AddScoped<IServiceAreaService, ServiceAreaService>();
            services.AddScoped<IUserService, UserService>();            
            services.AddScoped<ICcwJobService, CcwJobService>();
            services.AddScoped<ICCWNotificationService, CCWNotificationService>();

            var mappingConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToViewModelProfile());
                cfg.AddProfile(new ViewModelToModelProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
