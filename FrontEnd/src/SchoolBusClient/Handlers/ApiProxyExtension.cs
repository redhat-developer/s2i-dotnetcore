using Microsoft.AspNetCore.Builder;

namespace SchoolBusClient.Handlers
{
    public static class ApiProxyExtension
    {
        public static IApplicationBuilder UseApiProxyServer(this IApplicationBuilder app)
        {
            return app.MapWhen(ApiProxyMiddleware.IsApiPath, ProxyRequest);
        }

        private static void ProxyRequest(IApplicationBuilder app)
        {
            app.UseMiddleware<ApiProxyMiddleware>();
        }
    }
}
