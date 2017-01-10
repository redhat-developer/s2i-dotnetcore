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
            services.AddTransient<ICityApiService, CityApiService>();
            services.AddTransient<ICurrentUserApiService, CurrentUserApiService>();
            services.AddTransient<ICCWDataApiService, CCWDataApiService>();
            services.AddTransient<IDistrictApiService, DistrictApiService>();
            services.AddTransient<IGroupApiService, GroupApiService>();
            services.AddTransient<IInspectionApiService, InspectionApiService>();
            services.AddTransient<INotificationApiService, NotificationApiService>();
            services.AddTransient<INotificationEventApiService, NotificationEventApiService>();
            services.AddTransient<IPermissionApiService, PermissionApiService>();
            services.AddTransient<IRegionApiService, RegionApiService>();
            services.AddTransient<IRoleApiService, RoleApiService>();
            services.AddTransient<ISchoolBusApiService, SchoolBusApiService>();
            services.AddTransient<ISchoolBusAttachmentApiService, SchoolBusAttachmentApiService>();
            services.AddTransient<ISchoolBusHistoryApiService, SchoolBusHistoryApiService>();
            services.AddTransient<ISchoolBusNoteApiService, SchoolBusNoteApiService>();
            services.AddTransient<ISchoolBusOwnerApiService, SchoolBusOwnerApiService>();
            services.AddTransient<ISchoolBusOwnerAttachmentApiService, SchoolBusOwnerAttachmentApiService>();
            services.AddTransient<ISchoolBusOwnerContactApiService, SchoolBusOwnerContactApiService>();
            services.AddTransient<ISchoolBusOwnerHistoryApiService, SchoolBusOwnerHistoryApiService>();
            services.AddTransient<ISchoolBusOwnerNoteApiService, SchoolBusOwnerNoteApiService>();
            services.AddTransient<ISchoolDistrictApiService, SchoolDistrictApiService>();
            services.AddTransient<IServiceAreaApiService, ServiceAreaApiService>();
            services.AddTransient<IUserApiService, UserApiService>();            
            return services;
        }
    }
}
