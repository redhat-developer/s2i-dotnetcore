/*
 * REST API Documentation for Schoolbus
 *
 * This project is to replace the existing permitting and inspection scheduling functionality in AVIS  such that the mainframe application can be retired. 
 *
 * OpenAPI spec version: 1.0.0
 * 
 * 
 */

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SchoolBusAPI.Controllers;
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ICurrentUserService, CurrentUserService>();
            services.AddTransient<ICCWDataService, CCWDataService>();
            services.AddTransient<IDistrictService, DistrictService>();
            services.AddTransient<IGroupService, GroupService>();
            services.AddTransient<IInspectionService, InspectionService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<INotificationEventService, NotificationEventService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<ISchoolBusService, SchoolBusService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ISchoolBusOwnerService, SchoolBusOwnerService>();
            services.AddTransient<IAttachmentService, AttachmentService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IHistoryService, HistoryService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ISchoolDistrictService, SchoolDistrictService>();
            services.AddTransient<IServiceAreaService, ServiceAreaService>();
            services.AddTransient<IUserService, UserService>();            
            services.AddTransient<ITestService, TestService>();
            services.AddTransient<IAttachmentUploadService,AttachmentUploadService>();
            return services;
        }
    }
}
