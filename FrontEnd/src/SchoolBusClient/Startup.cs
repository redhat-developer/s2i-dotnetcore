using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using SchoolBusClient.Handlers;
using System;
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
            
            // Save this for later:
            // services.Configure<ApiProxyServerOptions>(Configuration.GetSection("ApiProxyServer"));
            services.Configure<ApiProxyServerOptions>(ConfigureApiProxyServerOptions);
        }

        // ToDo:
        // - Replace MIDDLEWARE_NAME environment variable with variables the can be used with ApiServerOptions:
        // -- ApiProxyServer:Scheme
        // -- ApiProxyServer:Host
        // -- ApiProxyServer:Port
        // - Remove use of IConfiguration and MIDDLEWARE_NAME environment variable 
        private void ConfigureApiProxyServerOptions(ApiProxyServerOptions options)
        {
            ApiProxyServerOptions defaultConfig = Configuration.GetSection("ApiProxyServer").Get<ApiProxyServerOptions>();
            if (defaultConfig != null)
            {
                options.Host = defaultConfig.Host;
                options.Port = defaultConfig.Port;
                options.Scheme = defaultConfig.Scheme;
            }

            string apiServerUri = Configuration["MIDDLEWARE_NAME"];
            if (apiServerUri != null)
            {
                string[] apiServerUriParts = apiServerUri.Split(':');
                string host = apiServerUriParts[0];
                string port = apiServerUriParts.Length > 1 ? apiServerUriParts[1] : "80";
                options.Scheme = "http";
                options.Host = host;
                options.Port = port;
            }
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

            string webFileFolder = Directory.GetCurrentDirectory();
            webFileFolder = webFileFolder + Path.DirectorySeparatorChar + "src"+ Path.DirectorySeparatorChar + "dist";

            Console.WriteLine("Web root is " +  webFileFolder);

            // Only serve up static files if they exist.
            if (Directory.Exists(webFileFolder))
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
