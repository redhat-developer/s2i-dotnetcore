using Microsoft.Extensions.Configuration;

namespace SchoolBusAPI.Extensions
{
    public static class IConfigurationExtensions
    {
        public static string GetEnvironment(this IConfiguration config)
        {
            var env = config.GetValue<string>("ASPNETCORE_ENVIRONMENT").ToUpperInvariant();

            switch (env)
            {
                case DotNetEnvironments.Prod:
                    return SbiEnvironments.Prod;
                case DotNetEnvironments.Dev:
                    return SbiEnvironments.Dev;
                case DotNetEnvironments.Test:
                    return SbiEnvironments.Test;
                default:
                    return SbiEnvironments.Unknown;
            }
        }
    }
}
