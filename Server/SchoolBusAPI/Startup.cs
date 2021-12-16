/*
 * REST API Documentation for Schoolbus
 *
 * API Sample
 *
 * OpenAPI spec version: v1
 * 
 * 
 */

using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using SchoolBusAPI.Authentication;
using SchoolBusAPI.Authorization;
using SchoolBusAPI.Extensions;
using SchoolBusAPI.Hangfire;
using SchoolBusAPI.Middlewares;
using SchoolBusAPI.Models;
using SchoolBusCcw;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.Json;

namespace SchoolBusAPI
{
    /// <summary>
    /// The application Startup class
    /// </summary>
    public class Startup
    {
        private IWebHostEnvironment _env;
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = GetConnectionString();

            services.AddHttpContextAccessor();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = Configuration.GetValue<string>("JWT:Authority");
                options.Audience = Configuration.GetValue<string>("JWT:Audience");
                options.IncludeErrorDetails = true;
                options.EventsType = typeof(SbJwtBearerEvents);
            });

            services.AddSingleton<IDbAppContextFactory, DbAppContextFactory>(CreateDbAppContextFactory);

            //Add database context
            //- Pattern should be using Configuration.GetConnectionString("Schoolbus") directly; see GetConnectionString for more details.
            services.AddDbContext<DbAppContext>(options => options.UseNpgsql(connectionString));

            services.AddCors();

            services
                .AddControllers(options =>
                {
                    var policy = new AuthorizationPolicyBuilder()
                        .RequireAuthenticatedUser()
                        .Build();
                    options.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                    options.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.RegisterPermissionHandler();
            services.AddScoped<SbJwtBearerEvents>();

            // allow for large files to be uploaded
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1073741824; // 1 GB
            });

            //enable Hangfire
            services.AddHangfire(configuration => 
                configuration
                .UseSerilogLogProvider()
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(connectionString)
            );

            services.AddHangfireServer(options =>
            {
                options.WorkerCount = 1;
            });

            // Configure Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "School Bus REST API",
                    Description = "School Bus Inspection System"
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "SchoolBusApi.xml");
                options.IncludeXmlComments(filePath);

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                options.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                options.AddSecurityRequirement(securityRequirement);
            });

            // Add application services.
            services.RegisterApplicationServices();

            services.AddHealthChecks()
                .AddNpgSql(connectionString, name: "SB-DB-Check", failureStatus: HealthStatus.Degraded, tags: new string[] { "pgsql", "db" });

            services.AddCCWServiceClient(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMiddleware<ExceptionMiddleware>();

            TryMigrateDatabase(app, logger);

            var healthCheckOptions = new HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    c.Response.ContentType = MediaTypeNames.Application.Json;
                    var result = JsonSerializer.Serialize(
                       new
                       {
                           checks = r.Entries.Select(e =>
                      new {
                          description = e.Key,
                          status = e.Value.Status.ToString(),
                          tags = e.Value.Tags,
                          responseTime = e.Value.Duration.TotalMilliseconds
                      }),
                           totalResponseTime = r.TotalDuration.TotalMilliseconds
                       });
                    await c.Response.WriteAsync(result);
                }
            };

            app.UseHealthChecks("/healthz", healthCheckOptions);

            //app.UseStatusCodePagesWithReExecute("/error/{0}");
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(Configuration.GetSection("Constants:SwaggerApiUrl").Value, "School Bus REST API v1");
                options.DocExpansion(DocExpansion.None);
            });

            // enable Hangfire Dashboard
            app.UseHangfireDashboard(); // this enables the /hangfire action

            // Only enable when doing a new PROD deploy to populate CCW data and link it to the bus data.
            var enableCcwCreate = (Configuration["ENABLE_HANGFIRE_CREATE"] ?? "N").ToUpperInvariant() == "Y";
            if (enableCcwCreate)
            {
                SetupHangfireCreateJob(logger);
            }

            var enableCcwUpdate = (Configuration["ENABLE_HANGFIRE_UPDATE"] ?? "N").ToUpperInvariant() == "Y";
            if (enableCcwUpdate)
            {
                SetupHangfireUpdateJob(logger);
            }

            logger.LogInformation($"CCW Population: {enableCcwCreate}, CCW Update: {enableCcwUpdate}");
        }

        // TODO:
        // - Should database migration be done here; in Startup?
        private void TryMigrateDatabase(IApplicationBuilder app, ILogger<Startup> logger)
        {
            logger.LogInformation("Attempting to migrate the database ...");

            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    logger.LogInformation("Fetching the application's database context ...");
                    DbContext context = serviceScope.ServiceProvider.GetService<DbAppContext>();

                    logger.LogInformation("Migrating the database ...");
                    context.Database.Migrate();
                    logger.LogInformation("The database migration complete.");

                    logger.LogInformation("Updating the databse documentation ...");
                    DbCommentsUpdater<DbAppContext> updater = new DbCommentsUpdater<DbAppContext>((DbAppContext)context);
                    updater.UpdateDatabaseDescriptions();
                    logger.LogInformation("The database documentation has been updated.");

                    logger.LogInformation("Adding/Updating seed data ...");
                    Seeders.SeedFactory<DbAppContext> seederFactory = new Seeders.SeedFactory<DbAppContext>(Configuration, _env, logger);
                    seederFactory.Seed(context as DbAppContext);
                    logger.LogInformation("Seeding operations are complete.");
                }

                logger.LogInformation("All database migration activities are complete.");
            }
            catch (Exception e)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("The database migration failed!");
                msg.AppendLine("The database may not be available and the application will not function as expected.");
                msg.AppendLine("Please ensure a database is available and the connection string is correct.");
                msg.AppendLine("If you are running in a development environment, ensure your test database and server configuration match the project's default connection string.");

                logger.LogCritical(new EventId(-1, "Database Migration Failed"), e, msg.ToString());
            }
        }

        // ToDo:
        // - Replace the individual environment variables with one that naturally works with the configuration provider and how connection strings work.
        // -- For instance:
        // --- ConnectionStrings:Schoolbus or ConnectionStrings__Schoolbus
        // -- This way the configuration provider is performing all of the lifting and the connection string can be retrieved in a single consistent manner.
        private string GetConnectionString()
        {
            string connectionString = string.Empty;

            string host = Configuration["DATABASE_SERVICE_NAME"];
            string username = Configuration["POSTGRESQL_USER"];
            string password = Configuration["POSTGRESQL_PASSWORD"];
            string database = Configuration["POSTGRESQL_DATABASE"];

            if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(database))
            {
                // When things get cleaned up properly, this is the only call we'll have to make.
                connectionString = Configuration.GetConnectionString("Schoolbus");
            }
            else
            {
                // Environment variables override all other settings; same behaviour as the configuration provider when things get cleaned up. 
                connectionString = $"Host={host};Username={username};Password={password};Database={database};";
            }

            return connectionString;
        }

        private DbAppContextFactory CreateDbAppContextFactory(IServiceProvider serviceProvider)
        {
            DbContextOptionsBuilder<DbAppContext> options = new DbContextOptionsBuilder<DbAppContext>();
            options.UseNpgsql(GetConnectionString());
            DbAppContextFactory dbAppContextFactory = new DbAppContextFactory(null, options.Options);
            return dbAppContextFactory;
        }

        /// <summary>
        /// Setup the Hangfire job to populate the CCW Data table.
        /// Only necessary after a new deploy to PROD with an empty database.
        /// </summary>
        /// <param name="logger"></param>
        private void SetupHangfireCreateJob(ILogger<Startup> logger)
        {
            logger.LogInformation("Attempting setup of Hangfire Create CCW job ...");

            // get credentials
            string cCW_userId = Configuration["CCW_userId"];
            string cCW_guid = Configuration["CCW_guid"];
            string cCW_directory = Configuration["CCW_directory"];
            string ccwHost = Configuration["CCW_SERVICE_NAME"];

            try
            {
                // every 30 minute we see if a CCW record needs to be created for a bus.  We only create one CCW record at a time.
                RecurringJob.AddOrUpdate<CcwJobService>(x => x.PopulateCCWJob(), $"*/30 * * * *");
                logger.LogInformation("Created Hangfire job for CCW population ...");
            }
            catch (Exception e)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("Failed to setup Hangfire job.");
                
                logger.LogCritical(new EventId(-1, "Hangfire job setup failed"), e, msg.ToString());
            }
        }

        /// <summary>
        /// Setup the Hangfire job to update the CCW Data table.        
        /// </summary>
        /// <param name="logger"></param>
        private void SetupHangfireUpdateJob(ILogger<Startup> logger)
        {
            logger.LogInformation("Attempting setup of Hangfire Update CCW job ...");
            
            try
            {
                // every 5 minutes we see if a CCW record needs to be updated.  We only update one CCW record at a time.
                RecurringJob.AddOrUpdate<CcwJobService>(x => x.UpdateCCWJob(), $"*/5 * * * *");
                logger.LogInformation("Created Hangfire job for CCW update ...");
            }
            catch (Exception e)
            {
                StringBuilder msg = new StringBuilder();
                msg.AppendLine("Failed to setup Hangfire job.");

                logger.LogCritical(new EventId(-1, "Hangfire job setup failed"), e, msg.ToString());
            }
        }
    }
}
