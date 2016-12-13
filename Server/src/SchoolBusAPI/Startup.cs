/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Swashbuckle.Swagger.Model;
using Swashbuckle.SwaggerGen.Annotations;
using Microsoft.EntityFrameworkCore;
using SchoolBusAPI.Models;

namespace SchoolBusAPI
{
    public class Startup
    {
        private readonly IHostingEnvironment _hostingEnv;

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            _hostingEnv = env;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
  
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Host=" + Configuration["DATABASE_SERVICE_NAME"] + "; Username=" + Configuration["POSTGRESQL_USER"] + "; Password=" + Configuration["POSTGRESQL_PASSWORD"] + "; Database=" + Configuration["POSTGRESQL_DATABASE"];                
            
            Console.WriteLine(connectionString);
            services.AddDbContext<DbAppContext>(
                opts => opts.UseNpgsql(connectionString)
            );
			
            // Add framework services.
            services.AddMvc()
                .AddJsonOptions(
                    opts => { opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver(); });
            
            services.AddSwaggerGen();
            
            services.ConfigureSwaggerGen(options =>
            {
                options.SingleApiVersion(new Info
                {
                    Version = "v1",
                    Title = "SchoolBusAPI",
                    Description = "SchoolBusAPI (ASP.NET Core 1.0.1)"
                });

                options.DescribeAllEnumsAsStrings();

                var comments = new XPathDocument($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{_hostingEnv.ApplicationName}.xml");
                options.OperationFilter<XmlCommentsOperationFilter>(comments);
                options.ModelFilter<XmlCommentsModelFilter>(comments);
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

			//if (env.IsDevelopment())
			//{
				app.UseDeveloperExceptionPage();
			//}
			
			// migrate database
			
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                // get the application's database context
                DbContext context = serviceScope.ServiceProvider.GetService<DbAppContext>();

                Console.WriteLine("Migrating database");
                // do any pending migrations
                context.Database.Migrate();
                
                // populate the column comments.  Comments are the PGSQL column descriptions
                DbCommentsUpdater<DbAppContext> updater = new DbCommentsUpdater<DbAppContext>((DbAppContext)context);
                updater.UpdateDatabaseDescriptions();

            }
			
            app.UseMvc();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
