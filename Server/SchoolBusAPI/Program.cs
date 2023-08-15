using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.IO;
using System;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using SchoolBusAPI.Authentication;
using SchoolBusAPI.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Newtonsoft.Json.Serialization;
using SchoolBusAPI.Authorization;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.OpenApi.Models;
using SchoolBusAPI.Extensions;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using SchoolBusAPI.Middlewares;
using Swashbuckle.AspNetCore.SwaggerUI;
using SchoolBusAPI.Seeders;
using SchoolBusAPI;
using System.Text;
using SchoolBusAPI.Hangfire;
using System.Net.Mime;
using System.Text.Json;
using System.Linq;
using Microsoft.AspNetCore.Http;
using SchoolBusCcw;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

var Configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
    .AddEnvironmentVariables()
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(Configuration)
    .CreateLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Register services here
    builder.Host.UseSerilog();
    builder.Configuration.AddEnvironmentVariables();

    string connectionString = GetConnectionString();

    builder.Services.AddHttpContextAccessor();
    builder.Services.AddAuthentication(options =>
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

    builder.Services.AddSingleton<IDbAppContextFactory, DbAppContextFactory>(CreateDbAppContextFactory);

    // Add database context
    //- Pattern should be using Configuration.GetConnectionString("Schoolbus") directly; see GetConnectionString for more details.
    builder.Services.AddDbContext<DbAppContext>(options => options.UseNpgsql(connectionString));
    builder.Services.AddCors();
    builder.Services
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
        });

    builder.Services.RegisterPermissionHandler();
    builder.Services.AddScoped<SbJwtBearerEvents>();

    // allow for large files to be uploaded
    builder.Services.Configure<FormOptions>(options =>
    {
        options.MultipartBodyLengthLimit = 1073741824; // 1 GB
    });

    // enable Hangfire
    builder.Services.AddHangfire(configuration =>
        configuration
            .UseSerilogLogProvider()
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UsePostgreSqlStorage(connectionString)
    );

    builder.Services.AddHangfireServer(options =>
    {
        options.WorkerCount = 1;
    });

    // Configure Swagger
    builder.Services.AddSwaggerGen(options =>
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

        var securityRequirement = new OpenApiSecurityRequirement
    {
        { securitySchema, new[] { "Bearer" } }
    };
        options.AddSecurityRequirement(securityRequirement);
    });

    // Add application services.
    builder.Services.RegisterApplicationServices();
    builder.Services.AddHealthChecks()
        .AddNpgSql(
            connectionString,
            name: "SB-DB-Check",
            failureStatus: HealthStatus.Degraded,
            tags: new string[] { "pgsql", "db" }
        );
    builder.Services.AddCCWServiceClient(Configuration);

    var app = builder.Build();

    // Use services here
    var env = app.Environment;
    if (env.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }
    app.UseMiddleware<ExceptionMiddleware>();

    TryMigrateDatabase(app, env);

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
                       }
                   ),
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
    app.MapControllers();
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
        SetupHangfireCreateJob();
    }

    var enableCcwUpdate = (Configuration["ENABLE_HANGFIRE_UPDATE"] ?? "N").ToUpperInvariant() == "Y";
    if (enableCcwUpdate)
    {
        SetupHangfireUpdateJob();
    }

    Log.Information($"CCW Population: {enableCcwCreate}, CCW Update: {enableCcwUpdate}");

    app.Run();
} 
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

// TODO:
// - Should database migration be done here, when the application starts?
void TryMigrateDatabase(IApplicationBuilder app, IWebHostEnvironment env)
{
    Log.Information("Attempting to migrate the database ...");

    try
    {
        using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
        {
            Log.Information("Fetching the application's database context ...");
            DbContext context = serviceScope.ServiceProvider.GetService<DbAppContext>();

            Log.Information("Migrating the database ...");
            context.Database.Migrate();
            Log.Information("The database migration complete.");

            Log.Information("Updating the databse documentation ...");
            DbCommentsUpdater<DbAppContext> updater = new((DbAppContext)context);
            updater.UpdateDatabaseDescriptions();
            Log.Information("The database documentation has been updated.");

            Log.Information("Adding/Updating seed data ...");
            SeedFactory<DbAppContext> seederFactory = new(Configuration, env);
            seederFactory.Seed(context as DbAppContext);
            Log.Information("Seeding operations are complete.");
        }

        Log.Information("All database migration activities are complete.");
    }
    catch (Exception e)
    {
        StringBuilder msg = new StringBuilder();
        msg.AppendLine("The database migration failed!");
        msg.AppendLine("The database may not be available and the application will not function as expected.");
        msg.AppendLine("Please ensure a database is available and the connection string is correct.");
        msg.AppendLine("If you are running in a development environment, ensure your test database and server configuration match the project's default connection string.");
        Log.Error(e, msg.ToString());
    }
}

// ToDo:
// - Replace the individual environment variables with one that naturally works with the configuration provider and how connection strings work.
// -- For instance:
// --- ConnectionStrings:Schoolbus or ConnectionStrings__Schoolbus
// -- This way the configuration provider is performing all of the lifting and the connection string can be retrieved in a single consistent manner.
string GetConnectionString()
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

DbAppContextFactory CreateDbAppContextFactory(IServiceProvider serviceProvider)
{
    DbContextOptionsBuilder<DbAppContext> options = new();
    options.UseNpgsql(GetConnectionString());
    // var logger = serviceProvider.GetRequiredService<ILogger<DbAppContext>>();
    DbAppContextFactory dbAppContextFactory = new(null, options.Options);
    return dbAppContextFactory;
}

/// <summary>
/// Setup the Hangfire job to populate the CCW Data table.
/// Only necessary after a new deploy to PROD with an empty database.
/// </summary>
/// <param name="logger"></param>
void SetupHangfireCreateJob()
{
    Log.Information("Attempting setup of Hangfire Create CCW job ...");

    // get credentials
    string cCW_userId = Configuration["CCW_userId"];
    string cCW_guid = Configuration["CCW_guid"];
    string cCW_directory = Configuration["CCW_directory"];
    string ccwHost = Configuration["CCW_SERVICE_NAME"];

    try
    {
        // every 30 minute we see if a CCW record needs to be created for a bus.  We only create one CCW record at a time.
        RecurringJob.AddOrUpdate<CcwJobService>("create_ccw_record", x => x.PopulateCCWJob(), $"*/30 * * * *");
        Log.Information("Created Hangfire job for CCW population ...");
    }
    catch (Exception e)
    {
        StringBuilder msg = new();
        msg.AppendLine("Failed to setup Hangfire job.");
        Log.Fatal(e, msg.ToString());
    }
}

/// <summary>
/// Setup the Hangfire job to update the CCW Data table.        
/// </summary>
/// <param name="logger"></param>
void SetupHangfireUpdateJob()
{
    Log.Information("Attempting setup of Hangfire Update CCW job ...");

    try
    {
        // every 5 minutes we see if a CCW record needs to be updated.  We only update one CCW record at a time.
        RecurringJob.AddOrUpdate<CcwJobService>("update_ccw_record", x => x.UpdateCCWJob(), $"*/5 * * * *");
        Log.Information("Created Hangfire job for CCW update ...");
    }
    catch (Exception e)
    {
        StringBuilder msg = new();
        msg.AppendLine("Failed to setup Hangfire job.");
        Log.Fatal(e, msg.ToString());
    }
}
