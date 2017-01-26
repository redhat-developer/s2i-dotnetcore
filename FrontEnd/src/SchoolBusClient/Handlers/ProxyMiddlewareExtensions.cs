using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace SchoolBusClient.Handlers
{
    public static class ProxyMiddlewareExtensions
    {
        public static IApplicationBuilder UseProxyServer<T, TOptions>(this IApplicationBuilder app) where T : ProxyMiddlewareBase<TOptions> where TOptions : ProxyServerOptions, new()
        {
            IOptions<TOptions> options =  app.ApplicationServices.GetService<IOptions<TOptions>>();
            return app.MapWhen((httpContext) => { return ProxyMiddlewareBase<TOptions>.IsApiPath(httpContext, options); }, ProxyRequest<T, TOptions>);
        }

        private static void ProxyRequest<T, TOptions>(IApplicationBuilder app) where T : ProxyMiddlewareBase<TOptions> where TOptions : ProxyServerOptions, new()
        {
            app.UseMiddleware<T>();
        }
    }
}
