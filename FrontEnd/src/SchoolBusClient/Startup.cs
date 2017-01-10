using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using SchoolBusClient.Handlers;
using System.IO;

namespace SchoolBusClient
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
            // Add framework services.
            services.AddMvc();

            // Allow access to the Configuration object
            services.AddSingleton<IConfiguration>(Configuration);
            services.Configure<ApiProxyServerOptions>(Configuration.GetSection("ApiProxyServer"));
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

            app.UseMvc();
            app.UseDefaultFiles();

            string webFileFolder = Path.Combine(Directory.GetCurrentDirectory(), @"src/dist");
            // Only serve up static files if they exist.
            if (File.Exists(webFileFolder))
            {
                app.UseFileServer(new FileServerOptions()
                {
                    // first see if the production folder is present.                
                    FileProvider = new PhysicalFileProvider(webFileFolder)
                });
            }

            app.UseApiProxyServer();
        }
    }
}
